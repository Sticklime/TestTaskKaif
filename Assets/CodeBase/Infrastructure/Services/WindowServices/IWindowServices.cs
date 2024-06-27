namespace CodeBase.Infrastructure.Services.WindowServices
{
    public interface IWindowServices
    {
        WindowBase OpenWindow(WindowType windowType);
    }
}