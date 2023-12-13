using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Dreamcore.Sound
{
	[Sound, Unique]
	public sealed class MusicOnComponent : IComponent { }
	
	[Sound, Unique]
	public sealed class SoundOnComponent : IComponent { }

	[Sound]
	public sealed class ClipComponent : IComponent
	{
		public SoundId Value;
		public static implicit operator SoundId(ClipComponent component) => component.Value;
		public override string ToString() => $"Clip[{Value}]";
	}

	[Sound]
	public sealed class ClipTypeComponent : IComponent
	{
		public SoundType Type;
		public static implicit operator SoundType(ClipTypeComponent component) => component.Type;
		public override string ToString() => $"ClipType[{Type}]";
	}

	[Sound]
	public sealed class InitializedComponent : IComponent
	{
		public override string ToString() => "Initialized";
	}

	[Sound]
	public sealed class VolumeComponent : IComponent
	{
		public float Value;

		public static implicit operator float(VolumeComponent component) => component.Value;
		public override string ToString() => $"Volume: {Value}";
	}

	[Sound]
	public sealed class PitchComponent : IComponent
	{
		public float Value;

		public static implicit operator float(PitchComponent component) => component.Value;
		public override string ToString() => $"Pitch: {Value}";
	}

	[Sound]
	public sealed class AudioClipComponent : IComponent
	{
		public AudioClip Reference;
		public override string ToString() => "AudioClipComponent";
	}

	[Sound]
	public sealed class LoopedComponent : IComponent
	{
		public override string ToString() => "Looped";
	}

	[Sound]
	public sealed class PlayingComponent : IComponent
	{
		public override string ToString() => "Playing";
	}

	[Sound]
	public sealed class StoppedComponent : IComponent
	{
		public override string ToString() => "Stopped";
	}

	[Sound]
	public sealed class AudioSourceComponent : IComponent
	{
		public AudioSource Component;
		public override string ToString() => "AudioSource";
	}

	[Sound]
	public sealed class AudioSourceTypeComponent : IComponent
	{
		public SoundType Type;
		public override string ToString() => "SourceType";
	}
	
	[Sound]
	public sealed class MutedComponent : IComponent
	{
		public override string ToString() => "Muted";
	}
	
	[Sound]
	public sealed class OneShotSoundComponent : IComponent
	{
		public override string ToString() => "OneShotSound";
	}

	[Sound, Unique]
	public sealed class SwallowSoundComponent : IComponent
	{
		public SoundId Value;
		public override string ToString() => "SwallowSound";
	}
}