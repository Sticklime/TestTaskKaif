using System.Collections;
using CodeBase.Infrastructure.State;
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

            _stateMachine.Enter<LoadGameState>();
        }

        private void RegisterState()
        {
            _stateMachine.RegisterState<LoadGameState>(_objectResolver.Resolve<LoadGameState>());
        }
    }
}