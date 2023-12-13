using System;
using System.Collections.Generic;

namespace Dreamcore.Statistics
{
	public class StatisticsEventHandler : IDisposable
	{
		private readonly List<IStatisticsChangedListener> _listeners;
		
		public StatisticsEventHandler(List<IStatisticsChangedListener> listeners) => 
			_listeners = listeners;

		public void OnStatisticsChanged(string parameter, StatisticsEntry entry)
		{
			foreach (var listener in _listeners) {
				if (listener.Accepts(parameter))
					listener.OnStatisticsChanged(parameter, entry);
			}
		}

		public void Subscribe(IStatisticsChangedListener listener) {
			if (_listeners.Contains(listener))
				throw new Exception("Already have that listener! " + listener);
			_listeners.Add(listener);
		}

		public void Unsubscribe(IStatisticsChangedListener listener) {
			if (!_listeners.Contains(listener))
				throw new Exception("Did not have that listener! " + listener);
			_listeners.Remove(listener);
		}

		public void Dispose() => _listeners.Clear();
	}
}