namespace Dreamcore.Core
{
	public class IdGenerator : IIdGenerator<int>
	{
		private static int _index = 0;
		
		public int Next() => _index++;
		public static int GetNext() => _index++;
	}
}