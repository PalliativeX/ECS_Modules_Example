using Entitas;
using UnityEngine;

namespace Dreamcore.Core
{
	public abstract class ABaseEcsBehaviour : MonoBehaviour
	{
		private IEntity _entity;

		public abstract void Unlink();
		
		public void Destroy() => Destroy(gameObject);

		public void CleanUp() => OnDestroyEntity(_entity);

		public void Link(IEntity entity)
		{
			Entitas.Unity.EntityLinkExtension.Link(gameObject, entity);
			_entity = entity;
			_entity.OnDestroyEntity += OnDestroyEntity;
		}

		private void OnDestroy()
		{
			if (_entity != null)
				OnDestroyEntity(_entity);
		}

		private void OnDestroyEntity(IEntity entity)
		{
			Unlink();
			Entitas.Unity.EntityLinkExtension.Unlink(gameObject);
			if (entity.isEnabled)
				_entity.OnDestroyEntity -= OnDestroyEntity;
			_entity = null;
		}
	}
}