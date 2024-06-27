using CodeBase.GameLogic.ClickEffect;
using CodeBase.GameLogic.Item;
using CodeBase.GameLogic.Store;
using CodeBase.Infrastructure.Services.WindowServices;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IUIFactory
    {
        void Load();
        WindowBase CreateWindow(WindowType windowType);
        void CreateNavigationBar();
        StoreContentView CreateStoreContent(Transform parent);
        ClickEffectView CreateEffectClick(Transform parent);
    }
}