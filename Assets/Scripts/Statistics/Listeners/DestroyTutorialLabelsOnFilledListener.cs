using Dreamcore.WorldCanvas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Statistics
{
	// NOTE: If we want to destroy tutorial labels on tutorial complete then uncomment back!
	// [InstallGameplay]
	public class DestroyTutorialLabelsOnFilledListener : IStatisticsChangedListener
	{
		private const string TutorialGatesOpenedKey = "TutorialGatesOpened";
		
		private readonly WorldCanvasContext _worldCanvas;

		public DestroyTutorialLabelsOnFilledListener(WorldCanvasContext worldCanvas) => 
			_worldCanvas = worldCanvas;

		public bool Accepts(string parameter) => parameter == TutorialGatesOpenedKey;

		public void OnStatisticsChanged(string parameter, StatisticsEntry entry)
		{
			var entities = _worldCanvas.GetEntitiesWithElementType(WorldCanvasElementType.TutorialLabel);
			foreach (WorldCanvasEntity entity in entities) 
				entity.isDestroyed = true;
		}
	}
}