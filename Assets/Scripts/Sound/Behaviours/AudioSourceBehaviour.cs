using UnityEngine;

namespace Dreamcore.Sound
{
	public sealed class AudioSourceBehaviour : MonoBehaviour
	{
		[SerializeField] private AudioSource _source;
		[SerializeField] private SoundType _type;

		public AudioSource Source => _source;
		public SoundType Type => _type;
	}
}