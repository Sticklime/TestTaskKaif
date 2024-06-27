using CodeBase.Infrastructure.Services.WindowServices;

namespace CodeBase.Infrastructure.Factory
{
    public interface IUIFactory
    {
        void Load();
        WindowBase CreateWindow(WindowType windowType);
    }
}