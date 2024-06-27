using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.ConfigProvider;
using CodeBase.Infrastructure.State;

namespace CodeBase.Infrastructure.StateMachine.State
{
    public class BootstrapperState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IUIFactory _uiFactory;
        private readonly IConfigProvider _configProvider;

        public BootstrapperState(IGameStateMachine stateMachine, IUIFactory uiFactory, IConfigProvider configProvider)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _configProvider = configProvider;
        }

        public void Enter()
        {
            _uiFactory.Load();
            _configProvider.Load();

            _stateMachine.Enter<LoadProgressState>();
        }

        public void Exit()
        {
        }
    }
}