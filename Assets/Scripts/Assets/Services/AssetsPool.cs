using System.Collections.Generic;
using Dreamcore.Core;
using UnityEngine;
using Zenject;

namespace Dreamcore.Assets
{
	public class AssetsPool : IInitializable, IAssetsPool
	{
		private readonly AssetsPoolConfig _poolConfig;
		private readonly AssetsStorage _storage;
		private readonly PoolContainer _poolContainer;

		private readonly Dictionary<string, Stack<GameObject>> _pooledObjects;

		public AssetsPool(AssetsPoolConfig poolConfig, AssetsStorage storage, PoolContainer poolContainer)
		{
			_poolConfig = poolConfig;
			_storage = storage;
			_poolContainer = poolContainer;
			_pooledObjects = new Dictionary<string, Stack<GameObject>>();
		}


		public void Initialize()
		{
			foreach (AssetPoolData poolData in _poolConfig.PoolData)
			{
				var stack = new Stack<GameObject>();

				for (int i = 0; i < poolData.PooledCount; i++)
				{
					GameObject instantiated = LoadAsset(poolData.Name, _poolContainer.Transform);
					instantiated.SetActive(false);
					stack.Push(instantiated);
				}

				_pooledObjects[poolData.Name] = stack;
			}
		}

		public (GameObject, bool isPooled) Get(string assetName, Transform parent)
		{
			bool isPooled = false;
			
			if (_pooledObjects.ContainsKey(assetName))
			{
				isPooled = true;
				if (_pooledObjects[assetName].Count > 0)
					return (_pooledObjects[assetName].Pop(), true);
			}

			return (LoadAsset(assetName, parent), isPooled);
		}

		public void Put(GameObject asset, string assetName)
		{
			asset.SetActive(false);
			asset.transform.parent = _poolContainer.Transform;
			_pooledObjects[assetName].Push(asset);
		}

		private GameObject LoadAsset(string assetName, Transform parent) => 
			Object.Instantiate(_storage.Get(assetName), parent);

		private void LogContents()
		{
			foreach ((string assetName, Stack<GameObject> stack) in _pooledObjects)
				D.Log("[AssetsPool]", assetName, stack.Count);
		}
	}
}