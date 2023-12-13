using System.Collections.Generic;

namespace Dreamcore.Statistics
{
	public sealed class StatisticsStorage
	{
		private readonly Dictionary<string, StatisticsEntry> _entries;

		public StatisticsStorage()
		{
			_entries = new Dictionary<string, StatisticsEntry>();
		}

		public StatisticsEntry Add(string key, StatisticsEntry entry)
		{
			if (_entries.ContainsKey(key))
				_entries[key] += entry;
			else
				_entries[key] = entry;

			return _entries[key];
		}

		public StatisticsEntry Get(string key) => _entries.ContainsKey(key) ? _entries[key] : default;

		public bool Has(string key) => _entries.ContainsKey(key);
		
		public void Clear() {
			_entries.Clear();
		}

		public void Remove(string key) {
			if(_entries.ContainsKey(key))
				_entries.Remove(key);
		}
		
		public IEnumerable<KeyValuePair<string, StatisticsEntry>> GetIEnumerable() => _entries;
	}
}