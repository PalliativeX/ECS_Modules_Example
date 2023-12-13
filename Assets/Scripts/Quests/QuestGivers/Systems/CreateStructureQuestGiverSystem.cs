using System.Collections.Generic;
using Dreamcore.WorldCanvas;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Quests
{
	[InstallGameplay(100_000)]
	public class CreateStructureQuestGiverSystem : ReactiveSystem<StructureEntity>
	{
		private readonly QuestGiverContext _questGiver;

		public CreateStructureQuestGiverSystem(StructureContext structure, QuestGiverContext questGiver) : base(structure) =>
			_questGiver = questGiver;

		protected override ICollector<StructureEntity> GetTrigger(IContext<StructureEntity> context) =>
			context.CreateCollector(StructureMatcher.QuestGiverId.Added());

		protected override bool Filter(StructureEntity entity) =>
			entity.hasQuestGiverId;

		protected override void Execute(List<StructureEntity> entities)
		{
			foreach (StructureEntity entity in entities)
			{
				QuestGiverEntity questGiver = _questGiver.Create(
					entity.id.Value,
					ContextType.Structure,
					entity.questGiverId.Value
				);
				questGiver.AddPosition(entity.position.Value);
			}
		}
	}
}