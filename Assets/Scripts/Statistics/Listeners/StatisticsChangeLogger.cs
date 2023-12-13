namespace Dreamcore.Statistics
{
	public class StatisticsChangeLogger : IStatisticsChangedListener
	{
		public bool Accepts(string parameter) => true;

		public void OnStatisticsChanged(string parameter, StatisticsEntry entry)
		{
#if DEBUG
			D.Log("[StatisticsChangeLogger]", parameter, ":", entry.ToString());
#endif
		}
	}
}