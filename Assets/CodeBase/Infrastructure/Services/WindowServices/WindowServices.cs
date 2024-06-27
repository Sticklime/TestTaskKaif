using CodeBase.Infrastructure.Factory;

namespace CodeBase.Infrastructure.Services.WindowServices
{
    public class WindowServices : IWindowServices
    {
        private readonly IUIFactory _uiFactory;

        private WindowType _currentWindow;

        public WindowServices(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void OpenWindow(WindowType windowType)
        {
            _uiFactory.CreateWindow(windowType);
        }
    }

    public interface IWindowServices
    {
        void OpenWindow(WindowType windowType);
    }

    public enum WindowType
    {
        Default = 0,
        ClickerWindow = 1,
    }
}