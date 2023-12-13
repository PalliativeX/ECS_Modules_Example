using System.Collections.Generic;
using Dreamcore.Integrations.Analytics;
using Dreamcore.Utils.Time;
using Entitas;
using Infrastructure.InstallerGenerator;

namespace Dreamcore.Statistics
{
	[InstallGameplay]
	public class EnemySwallowedStatisticsUpdateSystem : ReactiveSystem<GameEntity>
	{
		private const string EnemySwallowedAppendix = "EnemySwallowed.";
		
		private readonly GameContext _game;
		private readonly IStatistics _statistics;
		private readonly TutorialAnalytics _analytics;

		private readonly StringFast _builder = new StringFast();

		public EnemySwallowedStatisticsUpdateSystem(GameContext game, IStatistics statistics, TutorialAnalytics analytics) : base(game)
		{
			_game = game;
			_statistics = statistics;
			_analytics = analytics;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
			context.CreateCollector(GameMatcher.Swallowed.Added());

		protected override bool Filter(GameEntity entity) =>
			entity.isSwallowed;

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (GameEntity entity in entities)
			{
				if (entity.link.Id != _game.playerEntity.id.Value)
					continue;
					
				_statistics.Add(StatisticsKeys.EnemySwallowedKey);
				_statistics.Add(_builder.Append(EnemySwallowedAppendix).Append(entity.npcId.Value).ToString());
				_builder.Clear();

				if (_statistics.GetEntry(StatisticsKeys.EnemySwallowedKey).Count >= 3 &&
				    !_statistics.HasEntry(StatisticsKeys.TutorialGatesOpenedKey))
				{
					_statistics.Add(StatisticsKeys.TutorialGatesOpenedKey);
					_analytics.Send("enemies_swallowed");
				}
			}
		}
	}
}