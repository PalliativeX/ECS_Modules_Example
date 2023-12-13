using System;
using System.Collections.Generic;
using Dreamcore.Integrations.Analytics;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Quests
{
	[InstallGameplay(ExecutionPriority.VeryLow, 50)]
	public class QuestAnalyticsSystem : ReactiveSystem<QuestEntity>
	{
		private readonly QuestAnalytics _analytics;

		public QuestAnalyticsSystem(QuestContext quest, QuestAnalytics analytics) : base(quest) => 
			_analytics = analytics;

		protected override ICollector<QuestEntity> GetTrigger(IContext<QuestEntity> context) =>
			context.CreateCollector(QuestMatcher.QuestState.Added());

		protected override bool Filter(QuestEntity entity) =>
			entity.hasQuestState;

		protected override void Execute(List<QuestEntity> entities)
		{
			foreach (QuestEntity quest in entities)
			{
				switch (quest.questState.Value) {
					case QuestState.InProgress:
						break;
					case QuestState.ReadyToComplete:
						break;
					case QuestState.Completed:
						_analytics.OnQuestComplete(quest.questId.Value);
						break;
					default:
						break;
				}
			}
		}
	}
}