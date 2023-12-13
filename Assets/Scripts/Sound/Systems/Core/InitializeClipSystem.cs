using System.Collections.Generic;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Sound
{
	[InstallGameplay]
	public class InitializeClipSystem : ReactiveSystem<SoundEntity>
	{
		private readonly SoundStorage _storage;

		public InitializeClipSystem(SoundContextProvider sound, SoundStorage storage) : base(sound.Context)
		{
			_storage = storage;
		}

		protected override ICollector<SoundEntity> GetTrigger(IContext<SoundEntity> context)
			=> context.CreateCollector(SoundMatcher.Clip.Added());

		protected override bool Filter(SoundEntity entity)
			=> entity.hasClip;

		protected override void Execute(List<SoundEntity> entities)
		{
			foreach (var entity in entities)
			{
				SoundEntry entry = _storage.GetSound(entity.clip.Value);
				
				entity.AddAudioClip(entry.Clip);
				entity.AddVolume(entry.Volume);
				entity.AddPitch(entry.Pitch);
				entity.isLooped = entry.IsLooped;

				entity.isInitialized = true;
			}
		}
	}
}