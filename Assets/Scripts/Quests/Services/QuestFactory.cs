using Dreamcore.Statistics;

namespace Dreamcore.Quests
{
	public class QuestFactory
	{
		private readonly QuestStorage _questStorage;
		private readonly QuestContext _quest;
		private readonly IStatistics _statistics;

		public QuestFactory(QuestStorage questStorage, QuestContext quest, IStatistics statistics)
		{
			_questStorage = questStorage;
			_quest = quest;
			_statistics = statistics;
		}

		public QuestEntity Create(string questId)
		{
			QuestEntry questEntry = _questStorage.Get(questId);
			
			QuestEntity quest = _quest.Create();
			quest.AddQuestId(questEntry.Id);
			quest.AddQuestEntry(questEntry);
			quest.AddQuestState(QuestState.InProgress);
			quest.AddProgress(0f);
			
			foreach (QuestConditionEntry conditionEntry in questEntry.Conditions)
			{
				QuestEntity condition = CreateCondition(quest, conditionEntry);
			}

			return quest;
		}

		private QuestEntity CreateCondition(QuestEntity quest, QuestConditionEntry conditionEntry)
		{
			QuestEntity questCondition = _quest.Create();
			questCondition.AddParent(quest.id.Value);
			questCondition.AddKey(conditionEntry.StatisticsKey);
			ValueKey type = conditionEntry.KeyType;
			questCondition.AddKeyType(type);
			double value = _statistics.GetEntry(conditionEntry.StatisticsKey)[type];
			questCondition.AddStartOffset(type == ValueKey.Total ? 0 : value);
			questCondition.AddValue(value - questCondition.startOffset.Value);
			questCondition.AddDemand(conditionEntry.Count);
			questCondition.AddTargetType(conditionEntry.TargetType);
			questCondition.AddTargetReference(conditionEntry.TargetReference);
			questCondition.AddDescription(conditionEntry.Description);

			return questCondition;
		}
	}
}