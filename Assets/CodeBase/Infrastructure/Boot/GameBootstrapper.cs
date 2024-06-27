using CodeBase.Infrastructure.State;
using CodeBase.Infrastructure.StateMachine.State;
using UnityEngine;
using VContainer;

namespace CodeBase
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IGameStateMachine _stateMachine;
        private IObjectResolver _objectResolver;

        [Inject]
        public void Construct(IGameStateMachine stateMachine, IObjectResolver objectResolver)
        {
            _stateMachine = stateMachine;
            _objectResolver = objectResolver;
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            RegisterState();

            _stateMachine.Enter<BootstrapperState>();
        }

        private void RegisterState()
        {
            _stateMachine.RegisterState<BootstrapperState>(_objectResolver.Resolve<BootstrapperState>());
            _stateMachine.RegisterState<LoadProgressState>(_objectResolver.Resolve<LoadProgressState>());
            _stateMachine.RegisterState<LoadGameState>(_objectResolver.Resolve<LoadGameState>());
        }
    }
}