using System;
using Dreamcore.Core;
using Dreamcore.Npc;
using Dreamcore.WorldCanvas;

namespace Dreamcore.Quests
{
	public static class QuestGiverContextExtensions
	{
		public static QuestGiverEntity Create(
			this QuestGiverContext self,
			int ownerId,
			ContextType ownerType,
			QuestGiverId questGiverId
		)
		{
			QuestGiverEntity questGiver = self.CreateEntity();
			questGiver.AddId(ownerId);
			questGiver.AddOwnerType(ownerType);
			questGiver.AddQuestGiverId(questGiverId);
			questGiver.AddQuestGiverState(QuestGiverState.Idle);
			return questGiver;
		}

		public static void UpdateQuestGiverState(this QuestGiverEntity questGiver, QuestState state)
		{
			QuestGiverState questGiverState;
			switch (state) {
				case QuestState.InProgress:
					questGiverState = QuestGiverState.QuestActive;
					break;
				case QuestState.ReadyToComplete:
					questGiverState = QuestGiverState.QuestReadyToComplete;
					break;
				case QuestState.Completed:
					questGiverState = QuestGiverState.QuestComplete;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
				
			questGiver.ReplaceQuestGiverState(questGiverState);
		}
	}
}