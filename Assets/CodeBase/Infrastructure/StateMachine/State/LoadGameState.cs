using CodeBase;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.Infrastructure.Services.WindowServices;

public class LoadGameState : IState
{
    private const string PathGameScene = "GameScene";

    private readonly ISceneLoader _sceneLoader;
    private readonly IUIFactory _uiFactory;
    private readonly IWindowServices _windowServices;

    public LoadGameState(ISceneLoader sceneLoader, IUIFactory uiFactory, IWindowServices windowServices)
    {
        _sceneLoader = sceneLoader;
        _uiFactory = uiFactory;
        _windowServices = windowServices;
    }

    public async void Enter()
    {
        await _sceneLoader.Load(PathGameScene);

        _uiFactory.CreateNavigationBar();
        _windowServices.OpenWindow(WindowType.ClickerWindow);
    }

    public void Exit()
    {
    }
}