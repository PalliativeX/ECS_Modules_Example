using System.Collections.Generic;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Quests
{
	[InstallGameplay]
	public class UpdateStructureQuestGiverVisibilitySystem : ReactiveSystem<StructureEntity>
	{
		private readonly QuestGiverContext _questGiver;

		public UpdateStructureQuestGiverVisibilitySystem(StructureContext structure, QuestGiverContext questGiver) : base(structure) => 
			_questGiver = questGiver;

		protected override ICollector<StructureEntity> GetTrigger(IContext<StructureEntity> context) =>
			context.CreateCollector(StructureMatcher.InCameraFrustum.AddedOrRemoved());

		protected override bool Filter(StructureEntity entity) => 
			entity.hasQuestGiverId;

		protected override void Execute(List<StructureEntity> entities)
		{
			foreach (var entity in entities)
			{
				QuestGiverEntity questGiver = _questGiver.GetEntityWithQuestGiverId(entity.questGiverId.Value);
				questGiver.isInCameraFrustum = entity.isInCameraFrustum;
			}
		}
	}
}