using System;
using Dreamcore.Items;
using Dreamcore.Statistics;

namespace Dreamcore.Quests
{
	[Serializable]
	public class QuestEntry
	{
		public string Id;
		public string Name;
		public string Description;
		public string IconId;
		public string QuestGiverId;
		public Item[] Rewards;
		public QuestConditionEntry[] Conditions;
	}

	[Serializable]
	public class QuestConditionEntry
	{
		public string StatisticsKey;
		public ValueKey KeyType;
		public int Count;
		public string Description;

		public QuestTargetType TargetType;
		public string TargetReference;
		public bool UpdateDirectionDynamically;
	}
}