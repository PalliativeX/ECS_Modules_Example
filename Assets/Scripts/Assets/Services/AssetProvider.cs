using Dreamcore.Core;
using UnityEngine;

namespace Dreamcore.Assets
{
	public class AssetProvider : IAssetProvider
	{
		private readonly IAssetsPool _pool;
		private readonly GameParentProvider _parentProvider;

		public AssetProvider(IAssetsPool pool, GameParentProvider parentProvider)
		{
			_pool = pool;
			_parentProvider = parentProvider;
		}

		public (GameObject, bool isPooled) LoadAsset(string assetName)
		{
			(var instantiated, bool isPooled) = _pool.Get(assetName, _parentProvider.Parent);
			instantiated.SetActive(true);
			return (instantiated, isPooled);
		}

		public (T, bool isPooled) LoadAsset<T>(string assetName)
		{
			(GameObject instantiated, bool isPooled) = LoadAsset(assetName);
			return (instantiated.GetComponent<T>(), isPooled);
		}

		public (GameObject, bool isPooled) LoadAsset(string assetName, Vector3 position, Vector3 rotationEuler)
		{
			(GameObject instantiated, bool isPooled) = LoadAsset(assetName);
			instantiated.transform.position = position;
			instantiated.transform.eulerAngles = rotationEuler;
			return (instantiated, isPooled);
		}
	}
}