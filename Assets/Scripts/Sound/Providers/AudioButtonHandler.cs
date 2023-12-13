using System;
using System.Collections.Generic;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Sound
{
	[InstallGameplay]
	public class AudioButtonHandler : IDisposable
	{
		private readonly List<IAudioButtonBehaviour> _audioButtons = new List<IAudioButtonBehaviour>();
		private readonly SoundContext _sound;

		public AudioButtonHandler(SoundContextProvider sound) => _sound = sound;

		public void Subscribe(IAudioButtonBehaviour behaviour)
		{
			behaviour.Subscribe(
				() =>
				{
					if (behaviour.IsActive)
						_sound.PlayOneShot(behaviour.Id);
						// _sound.Play(behaviour.Id, SoundType.Sound);
				}
			);
			_audioButtons.Add(behaviour);
		}

		public void Unsubscribe(IAudioButtonBehaviour behaviour)
		{
			behaviour.Unsubscribe();
			_audioButtons.Remove(behaviour);
		}

		public void Dispose()
		{
			foreach (IAudioButtonBehaviour button in _audioButtons)
				button.Unsubscribe();
			_audioButtons.Clear();
		}
	}
}