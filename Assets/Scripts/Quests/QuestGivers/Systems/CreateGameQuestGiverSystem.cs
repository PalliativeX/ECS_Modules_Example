using System.Collections.Generic;
using Dreamcore.WorldCanvas;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Quests
{
	[InstallGameplay(100_000)]
	public class CreateGameQuestGiverSystem : ReactiveSystem<GameEntity>
	{
		private readonly QuestGiverContext _questGiver;

		public CreateGameQuestGiverSystem(GameContext game, QuestGiverContext questGiver) : base(game) =>
			_questGiver = questGiver;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
			context.CreateCollector(GameMatcher.QuestGiverId.Added());

		protected override bool Filter(GameEntity entity) =>
			entity.hasQuestGiverId;

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (GameEntity entity in entities)
			{
				QuestGiverEntity questGiver = _questGiver.Create(
					entity.id.Value,
					ContextType.Game,
					entity.questGiverId.Value
				);
				questGiver.AddPosition(entity.position.Value);
			}
		}
	}
}