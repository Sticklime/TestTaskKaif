using CodeBase.Data;
using CodeBase.DomainLogic;
using CodeBase.GameLogic.Purchases;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.ConfigProvider;
using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.Infrastructure.Services.WindowServices;
using CodeBase.Infrastructure.State;
using CodeBase.Infrastructure.StateMachine.State;
using CodeBase.ObjectPools;
using CodeBase.Services.SaveLoad;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Infrastructure.Bindings
{
    public class MainLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IGameStateMachine, State.StateMachine>(Lifetime.Singleton);
            builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
            builder.Register<IUIFactory, UIFactory>(Lifetime.Singleton);
            builder.Register<IWindowServices, WindowServices>(Lifetime.Singleton);
            builder.Register<IProgressProvider, ProgressProvider>(Lifetime.Singleton);
            builder.Register<IConfigProvider, ConfigProvider>(Lifetime.Singleton);
            builder.Register<ISaveLoadServices, SaveLoadServices>(Lifetime.Singleton);

            builder.Register<IObjectPool, ObjectPool>(Lifetime.Singleton);

            builder.Register<ScorePoint>(Lifetime.Singleton);
            builder.Register<ScoreClick>(Lifetime.Singleton);
            builder.Register<LevelHandler>(Lifetime.Singleton);
            builder.Register<PurchasesHandler>(Lifetime.Singleton);

            builder.Register<BootstrapperState>(Lifetime.Transient);
            builder.Register<LoadProgressState>(Lifetime.Transient);
            builder.Register<LoadGameState>(Lifetime.Transient);
        }
    }
}