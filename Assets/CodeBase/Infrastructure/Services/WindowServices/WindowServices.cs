using System.Collections.Generic;
using System.Linq;
using CodeBase.Infrastructure.Factory;

namespace CodeBase.Infrastructure.Services.WindowServices
{
    public class WindowServices : IWindowServices
    {
        private readonly IUIFactory _uiFactory;
        private readonly List<WindowBase> _windowsBase = new List<WindowBase>();

        private WindowType _currentWindow;

        public WindowServices(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public WindowBase OpenWindow(WindowType windowType)
        {
            if (_currentWindow == windowType)
                return null;

            WindowBase currentWindow;

            if (_windowsBase.Any(x => x.WindowType == windowType))
            {
                currentWindow = _windowsBase.First(x => x.WindowType == windowType);
                currentWindow.Open();
            }
            else
            {
                currentWindow = _uiFactory.CreateWindow(windowType);
                _windowsBase.Add(currentWindow);
            }

            CloseOtherWindow(windowType);

            return currentWindow;
        }

        private void CloseOtherWindow(WindowType windowType)
        {
            foreach (WindowBase windowBase in _windowsBase)
            {
                if (windowBase.WindowType != windowType)
                    windowBase.Close();
            }
        }
    }
}