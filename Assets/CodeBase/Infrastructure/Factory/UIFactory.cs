using System.Collections.Generic;
using System.Linq;
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

        public UIFactory(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        public void Load()
        {
            _windowPrefabs = Resources.LoadAll<WindowBase>(PathProvider.WindowPath).ToList();
        }

        public WindowBase CreateWindow(WindowType windowType)
        {
            WindowBase windowPrefab = _windowPrefabs.First(x => x.WindowType == windowType);

            return _objectResolver.Instantiate(windowPrefab);
        }
    }
}