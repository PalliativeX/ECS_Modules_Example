using Infrastructure.InstallerGenerator;
using Zenject;

namespace Dreamcore.Sound
{
	[InstallGameplay(ExecutionPriority.None, 102000)]
	public class MainThemePlaySystem : IInitializable
	{
		private readonly SoundContext _sound;
		
		public MainThemePlaySystem(SoundContextProvider sound)
		{
			_sound = sound;
		}

		public void Initialize() => _sound.Play(SoundId.MainTheme, SoundType.Music);
	}
}