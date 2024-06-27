using System.Collections;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.State;
using UnityEngine;
using VContainer;

namespace CodeBase
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IGameStateMachine _stateMachine;
        private IObjectResolver _objectResolver;
        private IUIFactory _uiFactory;

        [Inject]
        public void Construct(IGameStateMachine stateMachine, IObjectResolver objectResolver, IUIFactory uiFactory)
        {
            _stateMachine = stateMachine;
            _objectResolver = objectResolver;
            _uiFactory = uiFactory;
            StartGame();
        }

        private void StartGame()
        {
            DontDestroyOnLoad(gameObject);
            _uiFactory.Load();

            RegisterState();

            _stateMachine.Enter<LoadProgressState>();
        }

        private void RegisterState()
        {
            _stateMachine.RegisterState<LoadGameState>(_objectResolver.Resolve<LoadGameState>());
            _stateMachine.RegisterState<LoadProgressState>(_objectResolver.Resolve<LoadProgressState>());
        }
    }
}