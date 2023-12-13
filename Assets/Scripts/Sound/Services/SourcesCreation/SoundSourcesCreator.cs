using Infrastructure.InstallerGenerator;
using Zenject;

namespace Dreamcore.Sound
{
	[InstallGameplay(ExecutionPriority.Normal)]
	public class SoundSourcesCreator : IInitializable
	{
		private readonly AudioSourceCreatorService _sourceCreatorService;

		public SoundSourcesCreator(AudioSourceCreatorService sourceCreatorService) => 
			_sourceCreatorService = sourceCreatorService;

		public void Initialize() =>
			_sourceCreatorService.CreateSoundSources(SoundType.Sound);
	}
}