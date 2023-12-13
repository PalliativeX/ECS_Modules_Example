using System.Collections.Generic;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Quests
{
	[InstallGameplay]
	public class UpdateQuestTargetsSystem : ReactiveSystem<QuestEntity>
	{
		private readonly QuestTargetsProcessor _questTargets;

		public UpdateQuestTargetsSystem(QuestContext quest, QuestTargetsProcessor questTargets) : base(quest) => 
			_questTargets = questTargets;

		protected override ICollector<QuestEntity> GetTrigger(IContext<QuestEntity> context) =>
			context.CreateCollector(QuestMatcher.TargetType.Added(), QuestMatcher.Complete.Added());

		protected override bool Filter(QuestEntity entity) =>
			entity.hasTargetType && entity.hasTargetReference;

		protected override void Execute(List<QuestEntity> entities)
		{
			foreach (QuestEntity condition in entities)
			{
				_questTargets.SetQuestTargets(condition.targetType.Value, condition.targetReference.Value, !condition.isComplete);
			}
		}
	}
}