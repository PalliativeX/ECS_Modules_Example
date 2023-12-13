using System.Collections.Generic;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Quests
{
	[InstallGameplay(ExecutionPriority.VeryLow, 1_000_000)]
	public class DestroyQuestGiverSystem : ReactiveSystem<QuestGiverEntity>
	{
		public DestroyQuestGiverSystem(QuestGiverContext questGiver) : base(questGiver) { }

		protected override ICollector<QuestGiverEntity> GetTrigger(IContext<QuestGiverEntity> context) =>
			context.CreateCollector(QuestGiverMatcher.Destroyed.Added());

		protected override bool Filter(QuestGiverEntity entity) =>
			entity.isDestroyed;

		protected override void Execute(List<QuestGiverEntity> entities)
		{
			foreach (QuestGiverEntity entity in entities) 
				entity.Destroy();
		}
	}
}