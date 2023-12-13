using System;
using System.Collections.Generic;
using Dreamcore.Game;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Quests
{
	[InstallGameplay]
	public class SetSpawnedQuestTargetsSystem : ReactiveSystem<GameEntity>
	{
		private readonly IGroup<QuestEntity> _group;
		private readonly List<QuestEntity> _conditions;

		public SetSpawnedQuestTargetsSystem(GameContext game, QuestContext quest) : base(game)
		{
			_group = quest.GetGroup(QuestMatcher.TargetType);
			_conditions = new List<QuestEntity>();
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
			context.CreateCollector(GameMatcher.NpcId.Added());

		protected override bool Filter(GameEntity entity) =>
			entity.hasNpcId;

		protected override void Execute(List<GameEntity> entities)
		{
			_group.GetEntities(_conditions);
			if (_conditions.Count == 0)
			{
				_conditions.Clear();
				return;
			}

			foreach (QuestEntity condition in _conditions)
			{
				if (condition.targetType.Value != QuestTargetType.Enemy || condition.isComplete)
					continue;
				
				NpcId npcId = Enum.Parse<NpcId>(condition.targetReference.Value);
				foreach (GameEntity entity in entities)
					if (entity.npcId.Value == npcId)
						entity.isQuestTarget = true;
			}

			_conditions.Clear();
		}
	}
}