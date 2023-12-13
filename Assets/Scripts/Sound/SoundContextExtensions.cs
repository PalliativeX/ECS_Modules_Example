using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Dreamcore.Sound
{
	public static class SoundContextExtensions
	{
		public static SoundEntity Play(this SoundContext self, SoundId id, SoundType type)
		{
			SoundEntity entity = self.CreateEntity();
			entity.AddClip(id);
			entity.AddClipType(type);
			return entity;
		}

		public static SoundEntity PlayOneShot(this SoundContext self, SoundId id)
		{
			SoundEntity entity = self.CreateEntity();
			entity.AddClip(id);
			entity.AddClipType(SoundType.Sound);
			entity.isOneShotSound = true;
			return entity;
		}

		public static SoundEntity CreateAudioSource(this SoundContext sound, AudioSource audioSource, SoundType type)
		{
			SoundEntity entity = sound.CreateEntity();
			entity.AddAudioSource(audioSource);
			entity.AddAudioSourceType(type);
			return entity;
		}

		public static SoundContext StopAllSounds(this SoundContext self)
		{
			IEnumerable<SoundEntity> sounds = self.GetEntities(SoundMatcher.AudioSource);
			foreach (SoundEntity entity in sounds)
				entity.isStopped = true;

			return self;
		}
	}
}