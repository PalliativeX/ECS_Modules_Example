using System;
using Dreamcore.Ui.Behaviours;
using UnityEngine;

namespace Dreamcore.Sound
{
	[RequireComponent(typeof(ButtonEventsBehaviour))]
	public sealed class AudioButtonBehaviour : MonoBehaviour, IAudioButtonBehaviour
	{
		[SerializeField] private ButtonEventsBehaviour _buttonEvents;
		[SerializeField] private SoundId _id = SoundId.SimpleClick;

		private Action _callback;

		public SoundId Id => _id;

		public bool IsActive => _buttonEvents.IsActive;

		public void Subscribe(Action callback)
		{
			_callback = callback;
			_buttonEvents.OnPointerClickEvent += _callback;
		}

		public void Unsubscribe()
		{
			_buttonEvents.OnPointerClickEvent -= _callback;
			_callback = null;
		}
		
		private void OnDestroy() => Unsubscribe();

		#region AutoAssign
		
#if UNITY_EDITOR
		private void OnValidate()
		{
			if (_buttonEvents == null)
				_buttonEvents = GetComponent<ButtonEventsBehaviour>();
		}
#endif

		#endregion
	}
}