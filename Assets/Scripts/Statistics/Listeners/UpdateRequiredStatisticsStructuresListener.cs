using System.Collections.Generic;
using Dreamcore.Sound;
using Dreamcore.Structure;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Statistics
{
	[InstallGameplay]
	public class UpdateRequiredStatisticsStructuresListener : IStatisticsChangedListener
	{
		private readonly StructureContext _structure;
		private readonly SoundContext _sound;
		private readonly IGroup<StructureEntity> _group;
		private readonly List<StructureEntity> _statisticsStructures;
		
		public UpdateRequiredStatisticsStructuresListener(StructureContext structure, SoundContextProvider sound)
		{
			_structure = structure;
			_sound = sound;
			_group = structure.GetGroup(StructureMatcher.RequiredStatistics);
			_statisticsStructures = new List<StructureEntity>();
		}

		public bool Accepts(string parameter) => true;

		public void OnStatisticsChanged(string parameter, StatisticsEntry entry)
		{
			_group.GetEntities(_statisticsStructures);

			foreach (StructureEntity entity in _statisticsStructures)
			{
				if (entity.signal.Active || entity.requiredStatistics.Value != parameter)
					continue;
				
				entity.ReplaceSignal(true);

				// TODO: REMOVE IT FROM HERE!!!
				if (entity.structureType.Type == StructureType.Gates) 
					_sound.PlayOneShot(SoundId.GatesOpen);
			}
			
			_statisticsStructures.Clear();
		}

		private void AddGatesToQueue(StructureEntity gates)
		{
			List<int> gatesQueue = _structure.gatesOpenQueue.List;
			gatesQueue.Add(gates.id.Value);
			_structure.ReplaceGatesOpenQueue(gatesQueue);
		}
	}
}