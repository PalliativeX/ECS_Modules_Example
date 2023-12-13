using System.Collections.Generic;
using Dreamcore.WorldCanvas;
using Entitas;
using Infrastructure.InstallerGenerator;
using UnityEngine;

namespace Dreamcore.Quests
{
	[InstallGameplay(ExecutionPriority.VeryLow, 100)]
	public class QuestCompleteHandleInteractionSystem : ReactiveSystem<QuestEntity>
	{
		private readonly QuestGiverContext _questGiver;
		private readonly InteractionButtonProcessor _interactionButtonProcessor;
		private readonly InteractionContext _interaction;

		public QuestCompleteHandleInteractionSystem(
			QuestContext quest,
			QuestGiverContext questGiver,
			InteractionButtonProcessor interactionButtonProcessor,
			InteractionContext interaction
		) : base(quest)
		{
			_questGiver = questGiver;
			_interactionButtonProcessor = interactionButtonProcessor;
			_interaction = interaction;
		}

		protected override ICollector<QuestEntity> GetTrigger(IContext<QuestEntity> context) =>
			context.CreateCollector(QuestMatcher.QuestState.Added());

		protected override bool Filter(QuestEntity entity) =>
			entity.hasQuestState && entity.questState.Value == QuestState.Completed;

		protected override void Execute(List<QuestEntity> entities)
		{
			foreach (var entity in entities)
			{
				QuestGiverEntity questGiver = _questGiver.GetEntityWithQuestId(entity.questId.Value);
				InteractionEntity interaction = _interaction.GetEntityWithId(questGiver.id.Value);
				
				_interactionButtonProcessor.DestroyInteractionButtons(interaction);
			}
		}
	}
}