using Dreamcore.Statistics;
using Dreamcore.Utils;

namespace Dreamcore.Quests
{
	public class QuestStatisticsChangedListener : IStatisticsChangedListener
	{
		private readonly QuestContext _quest;
		
		public QuestStatisticsChangedListener(QuestContext quest) => _quest = quest;

		public bool Accepts(string parameter) => true;

		public void OnStatisticsChanged(string parameter, StatisticsEntry entry)
		{
			var questConditions = _quest.GetEntitiesWithKey(parameter);
			foreach (QuestEntity condition in questConditions)
			{
				if (condition.isComplete)
					continue;
				
				double value = entry[condition.keyType.Value] - condition.startOffset.Value;
				condition.ReplaceValue(value);
				if ((condition.value.Value / condition.demand.Value).IsEqualPrecise(1))
					condition.isComplete = true;
			}
		}
	}
}