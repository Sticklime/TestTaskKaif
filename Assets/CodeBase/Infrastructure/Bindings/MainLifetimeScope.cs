using CodeBase.Infrastructure.State;
using CodeBase.Services.Factory;
using CodeBase.Services.SceneLoader;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Infrastructure.Bindings
{
    public class MainLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IGameStateMachine, StateMachine>(Lifetime.Singleton);
            builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
            builder.Register<IUIFactory, UIFactory>(Lifetime.Singleton);
            builder.Register<LoadGameState>(Lifetime.Transient);
        }
    }
}