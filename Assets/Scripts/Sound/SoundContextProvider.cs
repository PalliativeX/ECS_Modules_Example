using Dreamcore.Core;

namespace Dreamcore.Sound
{
	public class SoundContextProvider : AContextProvider<SoundContext, SoundEntity> {
		public SoundContextProvider(SoundContext meta) : base(meta) { }
	}
}