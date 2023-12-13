using System.Collections.Generic;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Sound
{
	[InstallGameplay(ExecutionPriority.VeryLow, 1000000)]
	public class SoundDestroySystem : ReactiveSystem<SoundEntity>
	{
		public SoundDestroySystem(SoundContextProvider sound) : base(sound.Context)
		{ }

		protected override ICollector<SoundEntity> GetTrigger(IContext<SoundEntity> context)
			=> context.CreateCollector(SoundMatcher.Destroyed.Added());

		protected override bool Filter(SoundEntity entity)
			=> entity.isDestroyed;

		protected override void Execute(List<SoundEntity> entities)
		{
			foreach (var entity in entities) 
				entity.Destroy();
		}
	}
}