using Entitas;

namespace Dreamcore.Core
{
	public interface ILateSystem : ISystem
	{
		void LateTick();
	}
}