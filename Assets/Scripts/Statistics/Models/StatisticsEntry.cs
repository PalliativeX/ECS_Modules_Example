using System;

namespace Dreamcore.Statistics
{
	[Serializable]
	public class StatisticsEntry
	{
		public double Total { get; private set; }
		public double Last { get; private set; }
		public int Count { get; private set; }

		public StatisticsEntry(double value)
		{
			Total = value;
			Last = value;
			Count = 1;
		}

		public StatisticsEntry(double total, double last, int count)
		{
			Total = total;
			Last = last;
			Count = count;
		}

		public static StatisticsEntry operator +(StatisticsEntry a, StatisticsEntry b)
		{
			a.Total += b.Total;
			a.Count += b.Count;
			a.Last = b.Last;
			return a;
		}

		public double this[ValueKey key]
		{
			get
			{
				return key switch
				{
					ValueKey.Total => Total,
					ValueKey.Average => GetAverage(),
					ValueKey.Count => Count,
					ValueKey.Last => Last,
					_ => throw new ArgumentOutOfRangeException(nameof(key), key, null)
				};
			}
		}

		public double GetAverage() => Total / Count;
        
		public override string ToString() => $"Total[{Total}] Average[{GetAverage()}] Count[{Count}] Last[{Last}]";
	}
}