using System;
using Dreamcore.Assets.Spreadsheets;
using Dreamcore.Utils;
using UnityEngine;

namespace Dreamcore.Quests
{
	[CreateAssetMenu(fileName = "QuestStorage", menuName = "Storages/Quests/QuestStorage")]
	public sealed class QuestStorage : ADownloadableStorage
	{
		public QuestEntry[] Quests;
		
		public QuestEntry Get(string id)
		{
			var entry = Quests.FirstOrDefault(e => e.Id == id);
			if (entry != null)
				return entry;

			throw new Exception($"Quest not found for id '{id}'!");
		}
		
		public QuestEntry GetWithQuestGiver(QuestGiverId id)
		{
			var entry = Quests.FirstOrDefault(e => e.QuestGiverId == id);
			if (entry != null)
				return entry;

			throw new Exception($"Quest not found for QuestGiver '{id}'!");
		}
	}
}