using System.Collections.Generic;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Quests
{
	[InstallGameplay]
	public class ConditionValueChangedProgressSystem : ReactiveSystem<QuestEntity>
	{
		private readonly QuestContext _quest;

		public ConditionValueChangedProgressSystem(QuestContext quest) : base(quest) => 
			_quest = quest;

		protected override ICollector<QuestEntity> GetTrigger(IContext<QuestEntity> context) =>
			context.CreateCollector(QuestMatcher.Value);

		protected override bool Filter(QuestEntity entity) =>
			entity.hasValue && entity.hasParent;

		protected override void Execute(List<QuestEntity> entities)
		{
			foreach (var entity in entities)
			{
				var quest = _quest.GetEntityWithId(entity.parent.Id);
				var conditions = _quest.GetEntitiesWithParent(entity.parent.Id);
				float progress = 0f;
				foreach (QuestEntity condition in conditions)
				{
					progress += (float)((condition.value.Value / condition.demand.Value) / conditions.Count);
				}
				quest.ReplaceProgress(progress);
			}
		}
	}
}