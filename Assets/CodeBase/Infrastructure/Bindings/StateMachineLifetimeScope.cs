using CodeBase.Infrastructure.State;
using CodeBase.Services.SceneLoader;
using VContainer;
using VContainer.Unity;

namespace CodeBase
{
    public class StateMachineLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IGameStateMachine, StateMachine>(Lifetime.Singleton);
            builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
            builder.Register<LoadGameState>(Lifetime.Transient);
        }
    }
}