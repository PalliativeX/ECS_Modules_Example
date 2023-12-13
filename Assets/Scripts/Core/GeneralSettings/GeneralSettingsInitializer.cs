using UnityEngine;
using Zenject;

namespace Dreamcore.Core
{
	public class GeneralSettingsInitializer : IInitializable
	{
		private readonly GeneralSettingsConfig _generalSettings;

		public GeneralSettingsInitializer(GeneralSettingsConfig generalSettings) => 
			_generalSettings = generalSettings;

		public void Initialize()
		{
			QualitySettings.vSyncCount = _generalSettings.DisableVsync ? 0 : 1;
			Application.targetFrameRate = _generalSettings.TargetFrameRate;
			Screen.sleepTimeout = _generalSettings.SleepTimeout;

			Input.multiTouchEnabled = _generalSettings.IsEnableMultitouch;
		}
	}
}