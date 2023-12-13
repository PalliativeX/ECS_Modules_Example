using UnityEngine;

namespace Dreamcore.Core
{
	public class GameParentProvider
	{
		public Transform Parent { get; private set; }

		public void SetParent(Transform parent) => Parent = parent;

		public void RemoveParent() => Parent = null;

	}
}