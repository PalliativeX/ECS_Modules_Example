using System;
using System.Collections.Generic;
using Dreamcore.Utils;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Dreamcore.Assets
{
	[CreateAssetMenu(fileName = "AssetsStorage", menuName = "Storages/AssetsStorage")]
	public sealed class AssetsStorage : ScriptableObject
	{
		public List<Asset> Assets;

		public GameObject Get(string name)
		{
			Asset asset = Assets.FirstOrDefault(a => a.Name == name);
			if (asset != null && asset.Reference)
				return asset.Reference;

			throw new Exception($"Asset with name '{name}' not found!");
		}
	}

	[Serializable]
	public class Asset
	{
		public string Name;
		[AssetsOnly]
		public GameObject Reference;
	}
}