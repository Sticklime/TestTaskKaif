﻿using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.Infrastructure.Services.WindowServices;
using CodeBase.Infrastructure.State;
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
            builder.Register<IWindowServices, WindowServices>(Lifetime.Singleton);
            
            builder.Register<LoadGameState>(Lifetime.Transient);
        }
    }
}