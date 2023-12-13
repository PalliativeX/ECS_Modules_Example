using System.Collections.Generic;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Sound
{
	[InstallGameplay]
	public class PlayInitializedClipSystem : ReactiveSystem<SoundEntity>
	{
		private readonly MusicPlayer _musicPlayer;
		private readonly SoundPlayer _soundPlayer;

		public PlayInitializedClipSystem(
			SoundContextProvider sound,
			MusicPlayer musicPlayer,
			SoundPlayer soundPlayer
		) : base(sound.Context)
		{
			_musicPlayer = musicPlayer;
			_soundPlayer = soundPlayer;
		}

		protected override ICollector<SoundEntity> GetTrigger(IContext<SoundEntity> context)
			=> context.CreateCollector(SoundMatcher.Initialized.Added());

		protected override bool Filter(SoundEntity entity)
			=> entity.isInitialized && entity.hasClip;

		protected override void Execute(List<SoundEntity> entities)
		{
			foreach (var entity in entities)
			{
				if (entity.clipType.Type == SoundType.Music)
					_musicPlayer.Play(entity);
				else
					_soundPlayer.Play(entity);
			}
		}
	}
}