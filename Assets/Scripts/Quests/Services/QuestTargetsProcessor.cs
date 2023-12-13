using System;
using Dreamcore.Game;
using Dreamcore.Utils;
using Infrastructure.InstallerGenerator;
using UnityEngine;

namespace Dreamcore.Quests
{
	[InstallGameplay]
	public class QuestTargetsProcessor
	{
		private readonly GameContext _game;
		
		public QuestTargetsProcessor(GameContext game) => _game = game;

		public void SetQuestTargets(QuestTargetType targetType, string targetReference, bool active)
		{
			switch (targetType) {
				case QuestTargetType.Enemy:
					NpcId npcId = Enum.Parse<NpcId>(targetReference);
					var npcs = _game.GetEntitiesWithNpcId(npcId);
					foreach (GameEntity npc in npcs) 
						npc.isQuestTarget = active;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(targetType), targetType, null);
			}
		}
		
		// NOTE: We can return the average position of all enemies, but for now that will do
		public Vector3 GetQuestTargetPosition(QuestTargetType targetType, string targetReference)
		{
			switch (targetType) {
				case QuestTargetType.Enemy:
					NpcId npcId = Enum.Parse<NpcId>(targetReference);
					var npcs = _game.GetEntitiesWithNpcId(npcId);
					return npcs.First().position.Value;
				default:
					throw new ArgumentOutOfRangeException(nameof(targetType), targetType, null);
			}
		}
	}
}