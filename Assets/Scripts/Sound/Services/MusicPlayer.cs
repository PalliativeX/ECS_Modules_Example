using System.Linq;
using Infrastructure.InstallerGenerator;
using UnityEngine;
using Zenject;

namespace Dreamcore.Sound
{
	[InstallGameplay(ExecutionPriority.None, 120100)]
	public class MusicPlayer : IInitializable
	{
		private readonly SoundContext _sound;

		private SoundEntity[] _musicEntities;

		public MusicPlayer(SoundContextProvider sound) => 
			_sound = sound;

		public void Initialize() =>
			_musicEntities = _sound.GetGroup(SoundMatcher.AllOf(SoundMatcher.AudioSource, SoundMatcher.AudioSourceType))
				.GetEntities()
				.Where(e => e.audioSourceType.Type == SoundType.Music)
				.ToArray();

		public void Play(SoundEntity entity)
		{
			var inactiveEntity = GetInactiveEntity();
			if (TryGetActiveMusicEntity(out SoundEntity active)) 
				active.isStopped = true;

			inactiveEntity.isPlaying = true;
			AudioSource entitySource = inactiveEntity.audioSource.Component;
			entitySource.clip = entity.audioClip.Reference;
			entitySource.loop = entity.isLooped;
			entitySource.volume = entity.volume;
			entitySource.pitch = entity.pitch;
			entitySource.Play();

			entity.isDestroyed = true;
		}

		private bool TryGetActiveMusicEntity(out SoundEntity active)
		{
			active = _musicEntities.FirstOrDefault(e => e.isPlaying);
			return active != null;
		}

		private SoundEntity GetInactiveEntity() =>
			_musicEntities.FirstOrDefault(e => !e.isPlaying);
	}
}