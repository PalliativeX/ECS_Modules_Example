using Infrastructure.InstallerGenerator;
using Zenject;

namespace Dreamcore.Sound
{
	[InstallGameplay(ExecutionPriority.Normal)]
	public class MusicSourcesCreator : IInitializable
	{
		private readonly AudioSourceCreatorService _sourceCreatorService;

		public MusicSourcesCreator(AudioSourceCreatorService sourceCreatorService) => 
			_sourceCreatorService = sourceCreatorService;

		public void Initialize() =>
			_sourceCreatorService.CreateSoundSources(SoundType.Music);
	}
}