using System;
using System.Collections.Generic;
using Dreamcore.Utils;
using UnityEngine;

namespace Dreamcore.Assets
{
	[CreateAssetMenu(fileName = "AssetsPoolConfig", menuName = "Configs/AssetsPoolConfig")]
	public sealed class AssetsPoolConfig : ScriptableObject
	{
		public List<AssetPoolData> PoolData;

		public AssetPoolData Get(string name)
		{
			AssetPoolData asset = PoolData.FirstOrDefault(a => a.Name == name);
			if (asset != null)
				return asset;

			throw new Exception($"AssetPoolData with name '{name}' not found!");
		}
	}
	
	[Serializable]
	public class AssetPoolData
	{
		public string Name;
		public int PooledCount;
	}
}