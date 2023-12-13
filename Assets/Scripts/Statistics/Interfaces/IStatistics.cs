using System.Collections.Generic;

namespace Dreamcore.Statistics
{
	public interface IStatistics
	{
		IEnumerable<KeyValuePair<string, StatisticsEntry>> Entries { get; }
		
		void Add(string key, double value = 1);

		StatisticsEntry GetEntry(string key);

		bool HasEntry(string key);

		void ClearEntries();
	}
}