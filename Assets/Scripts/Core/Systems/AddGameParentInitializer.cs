using Dreamcore.Ui;
using Infrastructure.InstallerGenerator;
using Zenject;

namespace Dreamcore.Core.Systems
{
	[InstallGameplay(ExecutionPriority.Urgent)]
	public class AddGameParentInitializer : IInitializable
	{
		private readonly IGameParent _gameParent;
		private readonly GameParentProvider _parentProvider;
		
		public AddGameParentInitializer(IGameParent gameParent, GameParentProvider parentProvider)
		{
			_gameParent = gameParent;
			_parentProvider = parentProvider;
		}

		public void Initialize() => _parentProvider.SetParent(_gameParent.Parent);
	}
}