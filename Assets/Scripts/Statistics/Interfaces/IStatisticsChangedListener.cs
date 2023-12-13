namespace Dreamcore.Statistics
{
	public interface IStatisticsChangedListener
	{
		bool Accepts(string parameter);
		void OnStatisticsChanged(string parameter, StatisticsEntry entry);
	}
}