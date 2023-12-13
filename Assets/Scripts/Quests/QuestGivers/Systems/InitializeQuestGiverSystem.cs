using System.Collections.Generic;
using Dreamcore.Npc;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Quests
{
	[InstallGameplay(100_100)]
	public class InitializeQuestGiverSystem : ReactiveSystem<QuestGiverEntity>
	{
		private readonly QuestContext _quest;

		public InitializeQuestGiverSystem(QuestGiverContext questGiver, QuestContext quest) : base(questGiver) => 
			_quest = quest;

		protected override ICollector<QuestGiverEntity> GetTrigger(IContext<QuestGiverEntity> context) =>
			context.CreateCollector(QuestGiverMatcher.QuestGiverId.Added());

		protected override bool Filter(QuestGiverEntity entity) =>
			entity.hasQuestGiverId && entity.hasQuestId;

		protected override void Execute(List<QuestGiverEntity> entities)
		{
			foreach (QuestGiverEntity entity in entities)
			{
				QuestEntity quest = _quest.GetEntityWithQuestId(entity.questId.Value);
				if (quest == null)
					entity.ReplaceQuestGiverState(QuestGiverState.HasQuest);
				else
					entity.UpdateQuestGiverState(quest.questState.Value);
			}
		}
	}
}