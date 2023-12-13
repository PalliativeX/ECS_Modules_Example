using System.Collections.Generic;
using Entitas;
using Infrastructure.InstallerGenerator;
using UnityEngine;

namespace Dreamcore.Sound
{
	[InstallGameplay]
	public class InitializeAudioButtonBehavioursSystem : ReactiveSystem<UiEntity>
	{
		private readonly AudioButtonHandler _handler;

		public InitializeAudioButtonBehavioursSystem(UiContext ui, AudioButtonHandler handler) : base(ui) => 
			_handler = handler;

		protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context) =>
			context.CreateCollector(UiMatcher.RectTransform.Added());

		protected override bool Filter(UiEntity entity) =>
			entity.hasRectTransform;

		protected override void Execute(List<UiEntity> entities)
		{
			foreach (var entity in entities)
			{
				RectTransform transform = entity.rectTransform.Reference;
				AudioButtonBehaviour[] audioButtons = transform.GetComponentsInChildren<AudioButtonBehaviour>();
				foreach (var audioButton in audioButtons) 
					_handler.Subscribe(audioButton);
			}
		}
	}
}