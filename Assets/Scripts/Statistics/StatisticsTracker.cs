using System.Collections.Generic;

namespace Dreamcore.Statistics
{
	public class StatisticsTracker : IStatistics
	{
		private readonly StatisticsStorage _entries;
		private readonly StatisticsEventHandler _eventHandler;

		public IEnumerable<KeyValuePair<string, StatisticsEntry>> Entries => _entries.GetIEnumerable();
		
		public StatisticsTracker(StatisticsStorage storage, StatisticsEventHandler eventHandler)
		{
			_eventHandler = eventHandler;
			_entries = storage;
		}
		
		public void Add(string key, double value = 1)
		{
			var statisticsEntry = new StatisticsEntry(value);

			StatisticsEntry resultEntry = _entries.Add(key, statisticsEntry);
			
			_eventHandler.OnStatisticsChanged(key, resultEntry);
		}

		public StatisticsEntry GetEntry(string key)
		{
			return _entries.Has(key) ? _entries.Get(key) : new StatisticsEntry(0, 0, 0);
		}

		public bool HasEntry(string key) => _entries.Has(key);

		public void ClearEntries() => _entries.Clear();
	}
}