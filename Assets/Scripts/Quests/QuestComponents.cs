using Dreamcore.Statistics;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Dreamcore.Quests
{
	[Quest, QuestGiver]
	public sealed class QuestIdComponent : IComponent
	{
		[PrimaryEntityIndex] public string Value;
		
		public override string ToString() => $"QuestId:[{Value}]";
	}
	
	[Quest]
	public sealed class QuestEntryComponent : IComponent
	{
		public QuestEntry Value;
		
		public override string ToString() => "QuestEntry";
	}
	
	[Quest]
	public sealed class QuestStateComponent : IComponent
	{
		public QuestState Value;
		
		public override string ToString() => $"QuestState:[{Value}]";
	}
	
	[Quest]
	public sealed class ProgressComponent : IComponent
	{
		public float Value;
		
		public override string ToString() => "Progress";
	}
	
	[Quest]
	public sealed class CompleteComponent : IComponent
	{
		public override string ToString() => $"IsComplete";
	}
	
	[Quest]
	public sealed class KeyComponent : IComponent
	{
		[EntityIndex] public string Value;
		
		public override string ToString() => "Key";
	}
	
	[Quest]
	public sealed class KeyTypeComponent : IComponent
	{
		public ValueKey Value;
		
		public override string ToString() => "Key";
	}
	
	[Quest]
	public sealed class DemandComponent : IComponent
	{
		public double Value;

		public static implicit operator double(DemandComponent component) => component.Value;
		public override string ToString() => "Demand";
	}

	[Quest]
	public sealed class ValueComponent : IComponent
	{
		public double Value;

		public static implicit operator double(ValueComponent component) => component.Value;
		public override string ToString() => "Value";
	}
	
	[Quest]
	public sealed class StartOffsetComponent : IComponent
	{
		public double Value;

		public static implicit operator double(StartOffsetComponent component) => component.Value;
		public override string ToString() => "StartValue";
	}
	
	[Quest]
	public sealed class TargetTypeComponent : IComponent
	{
		public QuestTargetType Value;
		public override string ToString() => $"QuestTargetType:'{Value}'";
	}
	
	[Quest]
	public sealed class TargetReferenceComponent : IComponent
	{
		public string Value;
		public override string ToString() => $"QuestTargetReference:'{Value}'";
	}
}