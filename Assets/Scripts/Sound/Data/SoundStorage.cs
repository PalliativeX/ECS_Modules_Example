using System;
using System.Collections.Generic;
using Dreamcore.Utils;
using UnityEngine;

namespace Dreamcore.Sound
{
	[CreateAssetMenu(fileName = "SoundStorage", menuName = "Storages/SoundStorage")]
	public sealed class SoundStorage : ScriptableObject
	{
		public List<SoundEntry> Sounds;

		public SoundEntry GetSound(SoundId id)
		{
			SoundEntry entry = Sounds.FirstOrDefault(c => c.Id == id);
			if (entry == null)
				throw new Exception($"SoundEntry for id '{id}' not found!");

			return entry;
		}
	}
}