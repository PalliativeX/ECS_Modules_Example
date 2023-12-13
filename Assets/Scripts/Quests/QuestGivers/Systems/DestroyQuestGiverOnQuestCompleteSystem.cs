using System.Collections.Generic;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Quests
{
	[InstallGameplay(ExecutionPriority.VeryLow, 500)]
	public class DestroyQuestGiverOnQuestCompleteSystem : ReactiveSystem<QuestEntity>
	{
		private readonly QuestGiverContext _questGiver;
		private readonly GameContext _game;
		private readonly StructureContext _structure;

		public DestroyQuestGiverOnQuestCompleteSystem(
			QuestContext quest,
			QuestGiverContext questGiver,
			GameContext game,
			StructureContext structure
		) : base(quest)
		{
			_questGiver = questGiver;
			_game = game;
			_structure = structure;
		}

		protected override ICollector<QuestEntity> GetTrigger(IContext<QuestEntity> context) =>
			context.CreateCollector(QuestMatcher.Destroyed.Added());

		protected override bool Filter(QuestEntity entity) =>
			entity.isDestroyed && entity.hasQuestId;

		protected override void Execute(List<QuestEntity> entities)
		{
			foreach (var entity in entities)
			{
				QuestGiverEntity questGiver = _questGiver.GetEntityWithQuestId(entity.questId.Value);
				questGiver.isDestroyed = true;
				questGiver.isInCameraFrustum = false;

				int questGiverId = questGiver.id.Value;
				var gameEntity = _game.GetEntityWithId(questGiverId);
				if (gameEntity != null)
					gameEntity.isDestroyed = true;
					
				var structureEntity = _structure.GetEntityWithId(questGiverId);
				if (structureEntity != null)
					structureEntity.isDestroyed = true;
			}
		}
	}
}