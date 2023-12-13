using System.Collections.Generic;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Quests
{
	[InstallGameplay]
	public class UpdateGameQuestGiverVisibilitySystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _game;
		private readonly QuestGiverContext _questGiver;

		public UpdateGameQuestGiverVisibilitySystem(GameContext game, QuestGiverContext questGiver) : base(game)
		{
			_game = game;
			_questGiver = questGiver;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
			context.CreateCollector(GameMatcher.InCameraFrustum.AddedOrRemoved());

		protected override bool Filter(GameEntity entity) => 
			entity.hasQuestGiverId;

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var entity in entities)
			{
				QuestGiverEntity questGiver = _questGiver.GetEntityWithQuestGiverId(entity.questGiverId.Value);
				questGiver.isInCameraFrustum = entity.isInCameraFrustum;
			}
		}
	}
}