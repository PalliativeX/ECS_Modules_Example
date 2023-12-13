using Dreamcore.Npc;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Dreamcore.Quests
{
	[Game, Structure, QuestGiver]
	public sealed class QuestGiverIdComponent : IComponent
	{
		[PrimaryEntityIndex] public QuestGiverId Value;
		
		public override string ToString() => $"QuestGiverState:[{Value}]";
	}
	
	[QuestGiver]
	public sealed class QuestGiverStateComponent : IComponent
	{
		public QuestGiverState Value;
		
		public override string ToString() => $"QuestGiverState:[{Value}]";
	}
}