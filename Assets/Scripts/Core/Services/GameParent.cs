using UnityEngine;

namespace Dreamcore.Ui
{
	public sealed class GameParent : MonoBehaviour, IGameParent
	{
		[SerializeField] private Transform _parent;

		public Transform Parent => _parent;
	}
}