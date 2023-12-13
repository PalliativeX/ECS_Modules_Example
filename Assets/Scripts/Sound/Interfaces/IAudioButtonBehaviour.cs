using System;

namespace Dreamcore.Sound
{
	public interface IAudioButtonBehaviour
	{
		SoundId Id { get; }
		bool IsActive { get; }
		void Subscribe(Action callback);
		void Unsubscribe();
	}
}