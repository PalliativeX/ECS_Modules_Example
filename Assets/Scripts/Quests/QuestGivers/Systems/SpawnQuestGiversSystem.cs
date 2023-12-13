using Dreamcore.Statistics;
using Dreamcore.Structure;
using Dreamcore.Structure.Interfaces;
using Dreamcore.Utils.Time;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Quests
{
	/// <summary>
	/// Manual Quest Givers spawn only when a quest is not complete
	/// </summary>
	[InstallGameplay]
	public class SpawnQuestGiversSystem : ILocationInitializedListener
	{
		private const string QuestComplete = "QuestComplete.";

		private readonly IStatistics _statistics;
		private readonly StructureContext _structure;
		private readonly QuestStorage _quests;
		private readonly SpawnHandler _spawnHandler;

		private readonly StringFast _builder = new StringFast();

		public SpawnQuestGiversSystem(
			IStatistics statistics,
			StructureContext structure,
			QuestStorage quests,
			SpawnHandler spawnHandler
		)
		{
			_statistics = statistics;
			_structure = structure;
			_quests = quests;
			_spawnHandler = spawnHandler;
		}

		public void OnLocationInitialized()
		{
			foreach (QuestEntry quest in _quests.Quests)
			{
				bool isQuestComplete = _statistics.HasEntry(
					_builder.Append(QuestComplete).Append(quest.Id).ToString()
				);
				_builder.Clear();

				if (isQuestComplete)
					continue;

				StructureEntity spawnPoint =
					_structure.GetEntityWithSpawnQuestGiverId(new QuestGiverId(quest.QuestGiverId));
				GameEntity catcher = _spawnHandler.SpawnNpc(spawnPoint, spawnPoint.npcId.Value);
			}
		}
	}
}