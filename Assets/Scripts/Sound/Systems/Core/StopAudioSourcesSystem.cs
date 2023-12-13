using System.Collections.Generic;
using Entitas;
using Infrastructure.InstallerGenerator;
using UnityEngine;

namespace Dreamcore.Sound
{
	[InstallGameplay]
	public class StopAudioSourceSystem : IExecuteSystem
	{
		private readonly IGroup<SoundEntity> _group;
		private readonly List<SoundEntity> _buffer;
		
		public StopAudioSourceSystem(SoundContextProvider sound)
		{
			_group = sound.Context.GetGroup(SoundMatcher.AllOf(SoundMatcher.AudioSource, SoundMatcher.Playing));
			_buffer = new List<SoundEntity>();
		}

		public void Execute()
		{
			_group.GetEntities(_buffer);

			foreach (SoundEntity source in _buffer)
			{
				if (!source.audioSource.Component.isPlaying)
					source.isStopped = true;
				
				// if (GetClipRemainingTime(source.audioSource.Component) <= 0f)
					// source.isStopped = true;
			}
			
			_buffer.Clear();
		}
		
		// NOTE: Calculating the remainingTime of the given AudioSource
		// NOTE: This works most of the time, but sometimes for some reason source.clip.length returns 0
		// NOTE: (probably when the clip stopped playing), so it's easier to check AudioSource.isPlaying
		public static float GetClipRemainingTime(AudioSource source) => 
			(source.clip.length - source.time) / source.pitch;
	}
}