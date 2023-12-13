using System.Collections.Generic;
using Entitas;
using Infrastructure.InstallerGenerator;
using Zenject;

namespace Dreamcore.Sound
{
	[InstallGameplay]
	public class MusicOnChangedSystem : ReactiveSystem<SoundEntity>, IInitializable
	{
		private readonly SoundContext _sound;
		private readonly SourceMuteChangeProcessor _muteProcessor;

		public MusicOnChangedSystem(SoundContextProvider sound, SourceMuteChangeProcessor muteProcessor) : base(sound.Context)
		{
			_sound = sound;
			_muteProcessor = muteProcessor;
		}

		public void Initialize() => _muteProcessor.ChangeMute(SoundType.Music, _sound.isMusicOn);

		protected override ICollector<SoundEntity> GetTrigger(IContext<SoundEntity> context) =>
			context.CreateCollector(SoundMatcher.MusicOn.AddedOrRemoved());

		protected override bool Filter(SoundEntity entity) => true;

		protected override void Execute(List<SoundEntity> entities)
		{
			foreach (var entity in entities)
				_muteProcessor.ChangeMute(SoundType.Music, entity.isMusicOn);
		}
	}
}