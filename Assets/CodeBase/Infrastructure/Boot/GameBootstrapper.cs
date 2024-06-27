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
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            _uiFactory.Load();
            
            RegisterState();
            
            _stateMachine.Enter<LoadGameState>();
        }

        private void RegisterState()
        {
            _stateMachine.RegisterState<LoadGameState>(_objectResolver.Resolve<LoadGameState>());
        }
    }
}