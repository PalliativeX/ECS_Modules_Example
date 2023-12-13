using System.Collections.Generic;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Sound
{
	[InstallGameplay]
	public class SourceMuteChangeProcessor
	{
		private readonly IGroup<SoundEntity> _sourcesGroup;
		private readonly List<SoundEntity> _sourcesBuffer;
		
		public SourceMuteChangeProcessor(SoundContextProvider sound)
		{
			_sourcesGroup = sound.Context.GetGroup(
				SoundMatcher.AllOf(SoundMatcher.AudioSource, SoundMatcher.AudioSourceType)
			);
			_sourcesBuffer = new List<SoundEntity>();
		}

		public void ChangeMute(SoundType type, bool isOn)
		{
			_sourcesGroup.GetEntities(_sourcesBuffer);

				foreach (SoundEntity sourceEntity in _sourcesBuffer)
					if (sourceEntity.audioSourceType.Type == type)
						sourceEntity.isMuted = !isOn;

				_sourcesBuffer.Clear();
		}
	}
}