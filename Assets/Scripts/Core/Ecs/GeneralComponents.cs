using System;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using EventType = Entitas.CodeGeneration.Attributes.EventType;

namespace Dreamcore.Core
{
	[Game, Structure, View, Ui, Items, Upgrade, WorldCanvas, Effects, Meta, QuestGiver]
	public sealed class NameComponent : IComponent
	{
		[PrimaryEntityIndex] public string Value;
		public static implicit operator string(NameComponent component) => component.Value;
		public override string ToString() => Value;
	}
	
	[Game, Structure, View, Ui, Items, Upgrade, WorldCanvas, Effects, Meta, Quest, QuestGiver, Interaction]
	public sealed class IdComponent : IComponent
	{
		[PrimaryEntityIndex] public int Value;

		public static implicit operator int(IdComponent component) => component.Value;

		public override string ToString() => $"Id[{Value}]";
	}
	
	[Game, Structure, View, Ui, Items, Upgrade, WorldCanvas, Effects, Meta, Interaction]
	public sealed class OwnerComponent : IComponent
	{
		[EntityIndex] public int Id;

		public static implicit operator int(OwnerComponent component) => component.Id;

		public override string ToString() => $"Owner[{Id}]";
	}
	
	[Game, Structure, View, Ui, Items, Upgrade, WorldCanvas, Effects, Meta, Quest, Interaction]
	public sealed class ParentComponent : IComponent
	{
		[EntityIndex] public int Id;

		public static implicit operator int(ParentComponent component) => component.Id;

		public override string ToString() => $"Parent[{Id}]";
	}

	[Event(EventTarget.Self, EventType.Added)]
	[Event(EventTarget.Self, EventType.Removed)]
	[Game, Structure, View, Items, WorldCanvas, Effects, Sound, Quest, Interaction, QuestGiver]
	public sealed class PositionComponent : IComponent
	{
		public Vector3 Value;

		public static implicit operator Vector3(PositionComponent component) => component.Value;

		public override string ToString() => "Position";
	}

	[Event(EventTarget.Self)]
	[Event(EventTarget.Self, EventType.Removed)]
	[Game, Structure, View, WorldCanvas, Effects]
	public sealed class RotationComponent : IComponent
	{
		public Vector3 Value;

		public Quaternion Quaternion => Quaternion.Euler(Value);
		public Vector3 Direction => Quaternion.Euler(Value) * Vector3.forward;

		public static implicit operator Vector3(RotationComponent component) => component.Value;

		public override string ToString() => "Rotation";
	}

	[Game, Structure, View, WorldCanvas, Effects]
	public sealed class BehaviourComponent : IComponent
	{
		public MonoBehaviour Component;

		public override string ToString() => "Behaviour";
	}

	[Game, Structure, View, WorldCanvas, Effects]
	public sealed class ViewComponent : IComponent
	{
		public Transform Transform;
		public GameObject GameObject;
		public override string ToString() => "View";
	}

	[Game, Structure, View, WorldCanvas, Effects]
	public sealed class PrefabComponent : IComponent
	{
		public string Name;
		public override string ToString() => $"Prefab[{Name}]";
	}

	[Game, Structure, View, WorldCanvas, Effects]
	public sealed class PooledComponent : IComponent
	{
		public string Name;
		public override string ToString() => $"Pooled[{Name}]";
	}

	[Game, Structure, View, Ui, WorldCanvas, Effects, Upgrade, Meta, Quest]
	public sealed class InitializedComponent : IComponent
	{
		public override string ToString() => "Initialized";
	}

	[Game, Structure, View, Ui, Items, Upgrade, WorldCanvas, Effects, Sound, Meta, Quest, QuestGiver, Interaction]
	public sealed class DestroyedComponent : IComponent
	{
		public override string ToString() => "Destroyed";
	}

	[Event(EventTarget.Self)]
	[Event(EventTarget.Self, EventType.Removed)]
	[Game, Structure, View, Ui, WorldCanvas, Effects, Meta, Interaction]
	public sealed class ActiveComponent : IComponent
	{
		public override string ToString() => "IsActive";
	}

	[Event(EventTarget.Self)]
	[Event(EventTarget.Self, EventType.Removed)]
	[Game, Structure, View, Ui, WorldCanvas, Effects]
	public sealed class VisibleComponent : IComponent
	{
		public override string ToString() => "IsVisible";
	}
	
	[Meta]
	public sealed class BlockedComponent : IComponent
	{
		public override string ToString() => "Destroyed";
	}
	
	[Ui]
	public sealed class PoolElementComponent : IComponent
	{
		public override string ToString() => "PoolElement";
	}

	[Game]
	public sealed class CurrentMovementComponent : IComponent
	{
		public Vector3 Value;

		public static implicit operator Vector3(CurrentMovementComponent component) => component.Value;

		public override string ToString() => "CurrentMovement";
	}

	[Game, Structure, View, Ui, Items]
	public sealed class TotalCooldownComponent : IComponent
	{
		public float Value;

		public static implicit operator float(TotalCooldownComponent component) => component.Value;

		public override string ToString() => $"TotalCooldown[{Value}]";
	}

	[Game, Structure, View, Ui, Items, WorldCanvas, Meta]
	public sealed class CooldownComponent : IComponent
	{
		public float Value;

		public static implicit operator float(CooldownComponent component) => component.Value;

		public override string ToString() => $"Cooldown[{Value}]";
	}
	
	[Structure, Meta]
	public sealed class DurationComponent : IComponent
	{
		public float Value;

		public static implicit operator float(DurationComponent component) => component.Value;

		public override string ToString() => $"Duration[{Value}]";
	}
	
	[Game, Structure, View, Ui, Items, WorldCanvas]
	public sealed class TimestampComponent : IComponent
	{
		public double Value;

		public static implicit operator double(TimestampComponent component) => component.Value;

		public override string ToString() => $"Timestamp[{Value:F0}]";
	}

	[Event(EventTarget.Self)]
	[Event(EventTarget.Self, EventType.Removed)]
	[Ui, Game, View, Quest]
	public sealed class FloatComponent : IComponent
	{
		public float Value;
		public static implicit operator float(FloatComponent component) => component.Value;
		public override string ToString() => "Float";
	}

	[Event(EventTarget.Self)]
	[Event(EventTarget.Self, EventType.Removed)]
	[Ui]
	public sealed class FloatBoolComponent : IComponent
	{
		public float Value;
		public bool Active;
		public override string ToString() => "FloatBool";
	}
	
	[Event(EventTarget.Self)]
	[Event(EventTarget.Self, EventType.Removed)]
	[Ui]
	public sealed class IntBoolComponent : IComponent
	{
		public int Value;
		public bool Active;
		public override string ToString() => "IntBool";
	}

	[Event(EventTarget.Self)]
	[Event(EventTarget.Self, EventType.Removed)]
	[Ui]
	public sealed class FloatRangeBoolComponent : IComponent
	{
		public FloatRange Value;
		public bool Active;
		public override string ToString() => "FloatRangeBool";
	}

	[Event(EventTarget.Self)]
	[Event(EventTarget.Self, EventType.Removed)]
	[Ui, WorldCanvas, Structure]
	public sealed class BooleanComponent : IComponent
	{
		public bool Value;
		public override string ToString() => "Boolean";
	}

	[Event(EventTarget.Self)]
	[Event(EventTarget.Self, EventType.Removed)]
	[Ui]
	public sealed class IntComponent : IComponent
	{
		public int Value;
		public static implicit operator int(IntComponent component) => component.Value;
		public override string ToString() => "Int";
	}

	[Event(EventTarget.Self)]
	[Event(EventTarget.Self, EventType.Removed)]
	[Ui]
	public sealed class StringComponent : IComponent
	{
		public string Value;
		public static implicit operator string(StringComponent component) => component.Value;
		public override string ToString() => "String";
	}

	[Event(EventTarget.Self)]
	[Event(EventTarget.Self, EventType.Removed)]
	[Ui]
	public sealed class IndexComponent : IComponent
	{
		public int Value;
		public static implicit operator int(IndexComponent component) => component.Value;

		public override string ToString() => "Int";
	}

	[Event(EventTarget.Self)]
	[Event(EventTarget.Self, EventType.Removed)]
	[Ui]
	public sealed class CallbackComponent : IComponent
	{
		public Action Value;

		public override string ToString() => "Callback";
	}
	
	[Quest]
	public sealed class DescriptionComponent : IComponent
	{
		public string Value;
		public override string ToString() => "Description";
	}
}