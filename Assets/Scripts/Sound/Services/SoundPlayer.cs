using System.Linq;
using Infrastructure.InstallerGenerator;
using UnityEngine;
using Zenject;

namespace Dreamcore.Sound
{
	[InstallGameplay(ExecutionPriority.None, 120100)]
	public class SoundPlayer : IInitializable
	{
		private readonly SoundContext _sound;

		private SoundEntity[] _soundEntities;

		public SoundPlayer(SoundContextProvider sound) => 
			_sound = sound;

		public void Initialize() =>
			_soundEntities = _sound.GetGroup(SoundMatcher.AllOf(SoundMatcher.AudioSource, SoundMatcher.AudioSourceType))
				.GetEntities()
				.Where(e => e.audioSourceType.Type == SoundType.Sound)
				.ToArray();

		public void Play(SoundEntity entity)
		{
			entity.isDestroyed = true;
			
			if (entity.isOneShotSound)
			{
				AudioSource source = _soundEntities[0].audioSource.Component;
				source.PlayOneShot(entity.audioClip.Reference, entity.volume.Value);
				return;
			}
			
			SoundEntity inactiveEntity = GetInactiveEntity();
			if (inactiveEntity == null)
			{
#if UNITY_EDITOR
				D.Log("[SoundPlayer]", $"Free Audio Source not found for sound '{entity.audioClip.Reference.name}'");
#endif
				return;
			}

			// if (TryGetActiveMusicEntity(out SoundEntity active)) 
				// active.isStopped = true;

			AudioSource entitySource = inactiveEntity.audioSource.Component;
			entitySource.clip = entity.audioClip.Reference;
			entitySource.loop = entity.isLooped;
			entitySource.volume = entity.volume;
			entitySource.pitch = entity.pitch;
			if (entity.hasPosition)
				entitySource.transform.position = entity.position;
			entitySource.spatialBlend = entity.hasPosition ? 1f : 0f;
			entitySource.Play();
			
			inactiveEntity.isPlaying = true;
		}

		private bool TryGetActiveMusicEntity(out SoundEntity active)
		{
			active = _soundEntities.FirstOrDefault(e => e.isPlaying);
			return active != null;
		}

		private SoundEntity GetInactiveEntity() =>
			_soundEntities.FirstOrDefault(e => !e.isPlaying);
	}
}