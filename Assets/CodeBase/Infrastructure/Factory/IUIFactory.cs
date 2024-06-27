using CodeBase.Infrastructure.Services.WindowServices;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IUIFactory
    {
        void Load();
        WindowBase CreateWindow(WindowType windowType);
        GameObject CreateNavigationBar();
    }
}