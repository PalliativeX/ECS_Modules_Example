using System.Collections.Generic;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Statistics
{
	[InstallGameplay]
	public class UpdateRequiredStatisticsListenersOnLoadSystem : ReactiveSystem<StructureEntity>
	{
		private readonly IStatistics _statistics;

		public UpdateRequiredStatisticsListenersOnLoadSystem(StructureContext structure, IStatistics statistics) : base(structure) => 
			_statistics = statistics;

		protected override ICollector<StructureEntity> GetTrigger(IContext<StructureEntity> context) =>
			context.CreateCollector(StructureMatcher.RequiredStatistics.Added());

		protected override bool Filter(StructureEntity entity) =>
			entity.hasRequiredStatistics && (!entity.hasSignal || !entity.signal.Active);

		protected override void Execute(List<StructureEntity> entities)
		{
			foreach (StructureEntity entity in entities)
			{
				if (_statistics.HasEntry(entity.requiredStatistics.Value))
					entity.ReplaceSignal(true);
			}
		}
	}
}