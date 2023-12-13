using System.Collections.Generic;
using Dreamcore.Utils;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Quests
{
	[InstallGameplay]
	public class QuestProgressChangedSystem : ReactiveSystem<QuestEntity>
	{
		public QuestProgressChangedSystem(QuestContext quest) : base(quest) { }

		protected override ICollector<QuestEntity> GetTrigger(IContext<QuestEntity> context) =>
			context.CreateCollector(QuestMatcher.Progress.Added());

		protected override bool Filter(QuestEntity entity) =>
			entity.hasProgress && entity.progress.Value.IsEqualPrecise(1);

		protected override void Execute(List<QuestEntity> entities)
		{
			foreach (var entity in entities) 
				entity.ReplaceQuestState(QuestState.ReadyToComplete);
		}
	}
}