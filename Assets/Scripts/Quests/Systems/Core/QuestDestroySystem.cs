using System.Collections.Generic;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Quests
{
	[InstallGameplay(ExecutionPriority.VeryLow, 1_000_000)]
	public class QuestDestroySystem : ReactiveSystem<QuestEntity>
	{
		public QuestDestroySystem(QuestContext quest) : base(quest) { }

		protected override ICollector<QuestEntity> GetTrigger(IContext<QuestEntity> context)
			=> context.CreateCollector(QuestMatcher.Destroyed.Added());

		protected override bool Filter(QuestEntity entity)
			=> entity.isDestroyed;

		protected override void Execute(List<QuestEntity> entities)
		{
			foreach (var entity in entities) 
				entity.Destroy();
		}
	}
}