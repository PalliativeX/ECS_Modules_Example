namespace Dreamcore.Core
{
	public interface IIdGenerator<out T>
	{
		T Next();
	}
}