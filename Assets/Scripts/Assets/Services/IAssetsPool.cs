using UnityEngine;

namespace Dreamcore.Assets
{
	public interface IAssetsPool
	{
		(GameObject, bool isPooled) Get(string assetName, Transform parent);
		void Put(GameObject asset, string assetName);
	}
}