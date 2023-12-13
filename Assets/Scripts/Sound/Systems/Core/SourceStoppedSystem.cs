using System.Collections.Generic;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Sound
{
	[InstallGameplay]
	public class SourceStoppedSystem : ReactiveSystem<SoundEntity>
	{
		public SourceStoppedSystem(SoundContextProvider sound) : base(sound.Context)
		{ }

		protected override ICollector<SoundEntity> GetTrigger(IContext<SoundEntity> context)
			=> context.CreateCollector(SoundMatcher.Stopped.Added());

		protected override bool Filter(SoundEntity entity)
			=> entity.isStopped && entity.hasAudioSource;

		protected override void Execute(List<SoundEntity> entities)
		{
			foreach (var entity in entities)
			{
				var source = entity.audioSource.Component;
				source.Stop();
				source.clip = null;
				source.volume = 1f;
				source.loop = false;
				
				entity.isPlaying = false;
				entity.isStopped = false;
			}
		}
	}
}