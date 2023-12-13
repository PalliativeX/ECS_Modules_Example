using System.Collections.Generic;
using Infrastructure.InstallerGenerator;
using Zenject;

namespace Dreamcore.Statistics
{
	[InstallGameplay]
	public class StatisticsListenersAdder : IInitializable
	{
		private readonly StatisticsEventHandler _eventHandler;
		private readonly List<IStatisticsChangedListener> _statisticsListeners;

		public StatisticsListenersAdder(
			StatisticsEventHandler eventHandler,
			List<IStatisticsChangedListener> statisticsListeners
		)
		{
			_eventHandler = eventHandler;
			_statisticsListeners = statisticsListeners;
		}

		public void Initialize()
		{
			_eventHandler.Dispose();
			foreach (IStatisticsChangedListener listener in _statisticsListeners) 
				_eventHandler.Subscribe(listener);
		}
	}
}