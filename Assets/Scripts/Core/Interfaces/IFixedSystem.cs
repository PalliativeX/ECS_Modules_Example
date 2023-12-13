using Entitas;

namespace Dreamcore.Core
{
	public interface IFixedSystem : ISystem
	{
		void TickFixed();
	}
}