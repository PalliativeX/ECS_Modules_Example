using Dreamcore.Items;

namespace Dreamcore.Quests
{
	public class QuestProcessor
	{
		private readonly QuestContext _quest;
		private readonly ItemsContext _items;

		public QuestProcessor(QuestContext quest, ItemsContextProvider items)
		{
			_quest = quest;
			_items = items;
		}

		public void GiveQuestReward(QuestEntity quest)
		{
			Item[] rewards = quest.questEntry.Value.Rewards;
			_items.AddItems(rewards, ItemOperationType.Add);
		}
	}
}