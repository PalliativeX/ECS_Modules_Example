using Dreamcore.Assets;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Sound
{
	[InstallGameplay(ExecutionPriority.Normal)]
	public class AudioSourceCreatorService
	{
		private readonly SoundContext _sound;
		private readonly IAssetProvider _assetProvider;

		public AudioSourceCreatorService(SoundContextProvider sound, IAssetProvider assetProvider)
		{
			_sound = sound;
			_assetProvider = assetProvider;
		}

		public void CreateSoundSources(SoundType type)
		{
			string sourceName = type == SoundType.Music ? "MusicAudioSource" : "SoundAudioSource";
			int sourceCount = type == SoundType.Music ? 2 : 10;

			var audioEntities = new SoundEntity[sourceCount];
			for (int i = 0; i < audioEntities.Length; i++)
			{
				var source = _assetProvider.LoadAsset<AudioSourceBehaviour>(sourceName).Item1;
				
				audioEntities[i] = _sound.CreateAudioSource(source.Source, type);
			}
		}
	}
}