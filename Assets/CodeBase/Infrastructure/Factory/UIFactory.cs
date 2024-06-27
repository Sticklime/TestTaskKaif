using System.Collections.Generic;
using System.Linq;
using CodeBase.GameLogic.ClickEffect;
using CodeBase.GameLogic.Item;
using CodeBase.GameLogic.Store;
using CodeBase.Infrastructure.Services.WindowServices;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Infrastructure.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly IObjectResolver _objectResolver;

        private List<WindowBase> _windowPrefabs;
        private StoreContentView _storeContentPrefab;
        private GameObject _navigationBarPrefab;
        private ClickEffectView _clickEffectPrefab;

        public UIFactory(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        public void Load()
        {
            _windowPrefabs = Resources.LoadAll<WindowBase>(PathProvider.WindowPath).ToList();
            _navigationBarPrefab = Resources.Load<GameObject>(PathProvider.NavigationBarPath);
            _storeContentPrefab = Resources.Load<StoreContentView>(PathProvider.ShopContentPath);
            _clickEffectPrefab = Resources.Load<ClickEffectView>(PathProvider.ClickEffectPath);
        }

        public WindowBase CreateWindow(WindowType windowType)
        {
            WindowBase windowPrefab = _windowPrefabs.First(x => x.WindowType == windowType);

            return _objectResolver.Instantiate(windowPrefab);
        }

        public void CreateNavigationBar() =>
            _objectResolver.Instantiate(_navigationBarPrefab);

        public StoreContentView CreateStoreContent(Transform parent) =>
            _objectResolver.Instantiate(_storeContentPrefab, parent);

        public ClickEffectView CreateEffectClick(Transform parent) => 
            _objectResolver.Instantiate(_clickEffectPrefab, parent);
    }
}