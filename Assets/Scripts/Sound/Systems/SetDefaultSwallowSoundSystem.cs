using Infrastructure.InstallerGenerator;
using Zenject;

namespace Dreamcore.Sound
{
	[InstallGameplay(ExecutionPriority.High)]
	public class SetDefaultSwallowSoundSystem : IInitializable
	{
		private readonly SoundContext _sound;
		
		public SetDefaultSwallowSoundSystem(SoundContextProvider sound) => _sound = sound;

		public void Initialize()
		{
			_sound.ReplaceSwallowSound(SoundId.Swallow);
		}
	}
}