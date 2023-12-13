using Dreamcore.Utils;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Quests
{
	[InstallGameplay]
	public class QuestHelper
	{
		private readonly QuestContext _quest;
		
		public QuestHelper(QuestContext quest)
		{
			_quest = quest;
		}

		public (double, double) GetQuestProgress(QuestEntity quest)
		{
			QuestEntity questCondition = _quest.GetEntitiesWithParent(quest.id.Value).First();
			return (questCondition.value.Value, questCondition.demand.Value);
		}

		public string GetConditionDescription(QuestEntity quest)
		{
			QuestEntity questCondition = _quest.GetEntitiesWithParent(quest.id.Value).First();
			return questCondition.description.Value;
		}
	}
}