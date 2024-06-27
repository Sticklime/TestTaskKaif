using CodeBase.Data;
using CodeBase.Infrastructure.State;

namespace CodeBase
{
    public class LoadProgressState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IProgressProvider _progressProvider;

        public LoadProgressState(IGameStateMachine gameStateMachine, IProgressProvider progressProvider)
        {
            _gameStateMachine = gameStateMachine;
            _progressProvider = progressProvider;
        }

        public void Enter()
        {
            var clickData = new ClickData(0, 0);
            var levelData = new LevelData(0, 0, 10);

            _progressProvider.PlayerData = new PlayerData(clickData, levelData);

            _gameStateMachine.Enter<LoadGameState>();
        }

        public void Exit()
        {
        }
    }
}