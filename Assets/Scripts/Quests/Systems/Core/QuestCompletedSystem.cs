using System.Collections.Generic;
using Entitas;

namespace Dreamcore.Quests
{
	public class QuestCompletedSystem : ReactiveSystem<QuestEntity>
	{
		private readonly QuestContext _quest;
		private readonly QuestProcessor _questProcessor;

		public QuestCompletedSystem(QuestContext quest, QuestProcessor questProcessor) : base(quest)
		{
			_quest = quest;
			_questProcessor = questProcessor;
		}

		protected override ICollector<QuestEntity> GetTrigger(IContext<QuestEntity> context) =>
			context.CreateCollector(QuestMatcher.QuestState.Added());

		protected override bool Filter(QuestEntity entity) =>
			entity.hasQuestState && entity.questState.Value == QuestState.Completed;

		protected override void Execute(List<QuestEntity> entities)
		{
			foreach (QuestEntity quest in entities)
			{
				_questProcessor.GiveQuestReward(quest);
				
				quest.isDestroyed = true;
				
				var conditions = _quest.GetEntitiesWithParent(quest.id.Value);
				foreach (QuestEntity condition in conditions) 
					condition.isDestroyed = true;
			}
		}
	}
}