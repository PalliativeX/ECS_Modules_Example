using System.Collections.Generic;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Sound
{
	[InstallGameplay]
	public class MutedChangedSystem : ReactiveSystem<SoundEntity>
	{
		public MutedChangedSystem(SoundContextProvider sound) : base(sound.Context)
		{ }

		protected override ICollector<SoundEntity> GetTrigger(IContext<SoundEntity> context) =>
			context.CreateCollector(SoundMatcher.Muted.AddedOrRemoved());

		protected override bool Filter(SoundEntity entity) =>
			entity.hasAudioSource;

		protected override void Execute(List<SoundEntity> entities)
		{
			foreach (var entity in entities) 
				entity.audioSource.Component.mute = entity.isMuted;
		}
	}
}