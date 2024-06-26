namespace CodeBase.Infrastructure.Services.WindowServices
{
    public class WindowServices : IWindowServices
    {
    }

    public interface IWindowServices
    {
        void OpenWindow(WindowType windowType)
        {
        }
    }

    public enum WindowType
    {
        Default = 0,
    }
}