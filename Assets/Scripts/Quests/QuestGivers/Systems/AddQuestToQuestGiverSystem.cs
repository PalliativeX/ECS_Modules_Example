using System.Collections.Generic;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Quests
{
	[InstallGameplay(100_050)]
	public class AddQuestToQuestGiverSystem : ReactiveSystem<QuestGiverEntity>
	{
		private readonly QuestStorage _quests;

		public AddQuestToQuestGiverSystem(QuestGiverContext questGiver, QuestStorage quests) : base(questGiver) => 
			_quests = quests;

		protected override ICollector<QuestGiverEntity> GetTrigger(IContext<QuestGiverEntity> context) =>
			context.CreateCollector(QuestGiverMatcher.QuestGiverId.Added());

		protected override bool Filter(QuestGiverEntity entity) =>
			entity.hasQuestGiverId;

		protected override void Execute(List<QuestGiverEntity> entities)
		{
			foreach (var entity in entities)
			{
				QuestEntry quest = _quests.GetWithQuestGiver(entity.questGiverId.Value);
				entity.AddQuestId(quest.Id);
			}
		}
	}
}