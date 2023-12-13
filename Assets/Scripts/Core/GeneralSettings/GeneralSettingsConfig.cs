using UnityEngine;

namespace Dreamcore.Core
{
	[CreateAssetMenu(fileName = "GeneralSettings", menuName = "Configs/GeneralSettings")]
	public sealed class GeneralSettingsConfig : ScriptableObject
	{
		public bool DisableVsync = true;
		public int TargetFrameRate = 60;
		
		public int SleepTimeout = UnityEngine.SleepTimeout.NeverSleep;

		public bool IsEnableMultitouch = false;
	}
}