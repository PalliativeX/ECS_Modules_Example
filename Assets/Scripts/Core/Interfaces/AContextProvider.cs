using Entitas;

namespace Dreamcore.Core
{
	public abstract class AContextProvider<T, TEntity>
		where T : Context<TEntity>
		where TEntity : Entity
	{
		public T Context { get; }

		protected AContextProvider(T meta) => Context = meta;

		public static implicit operator T(AContextProvider<T, TEntity> provider) => provider.Context;
	}
}