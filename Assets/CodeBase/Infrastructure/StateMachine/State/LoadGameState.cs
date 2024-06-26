using CodeBase;
using CodeBase.Services.SceneLoader;

public class LoadGameState : IState
{
    private const string PathGameScene = "GameScene";

    private readonly ISceneLoader _sceneLoader;

    public LoadGameState(ISceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    public async void Enter()
    {
        await _sceneLoader.Load(PathGameScene);
    }

    public void Exit()
    {
    }
}