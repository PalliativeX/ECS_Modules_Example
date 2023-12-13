using System.Collections.Generic;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Quests
{
	[InstallGameplay(ExecutionPriority.VeryLow, 200)]
	public class SynchronizeQuestStateSystem : ReactiveSystem<QuestEntity>
	{
		private readonly QuestGiverContext _questGiver;

		public SynchronizeQuestStateSystem(QuestContext quest, QuestGiverContext questGiver) : base(quest) => 
			_questGiver = questGiver;

		protected override ICollector<QuestEntity> GetTrigger(IContext<QuestEntity> context) =>
			context.CreateCollector(QuestMatcher.QuestState.Added());

		protected override bool Filter(QuestEntity entity) =>
			entity.hasQuestState;

		protected override void Execute(List<QuestEntity> entities)
		{
			foreach (var entity in entities)
			{
				QuestGiverEntity questGiver = _questGiver.GetEntityWithQuestId(entity.questId.Value);
				questGiver.UpdateQuestGiverState(entity.questState.Value);
			}
		}
	}
}