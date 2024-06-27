using CodeBase;
using CodeBase.DomainLogic;
using CodeBase.GameLogic.ClickEffect;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.Infrastructure.Services.WindowServices;
using CodeBase.ObjectPools;
using UnityEngine;

public class LoadGameState : IState
{
    private const string PathGameScene = "GameScene";
    private const int CountEffectClick = 100;

    private readonly ISceneLoader _sceneLoader;
    private readonly IUIFactory _uiFactory;
    private readonly IWindowServices _windowServices;
    private readonly IObjectPool _objectPool;

    public LoadGameState(ISceneLoader sceneLoader, IUIFactory uiFactory, IWindowServices windowServices,
        IObjectPool objectPool)
    {
        _sceneLoader = sceneLoader;
        _uiFactory = uiFactory;
        _windowServices = windowServices;
        _objectPool = objectPool;
    }

    public async void Enter()
    {
        await _sceneLoader.Load(PathGameScene);

        InitUI();
    }

    private void InitUI()
    {
        _uiFactory.CreateNavigationBar();
        WindowBase clickerWindow = _windowServices.OpenWindow(WindowType.ClickerWindow);
        ClickerButtonView clickerButtonView = clickerWindow.GetComponentInChildren<ClickerButtonView>();

        for (int i = 0; i < CountEffectClick; i++)
        {
            ClickEffectView effectInstance = _uiFactory.CreateEffectClick(clickerButtonView.transform);
            _objectPool.LoadPool(effectInstance.gameObject);
        }
    }

    public void Exit()
    {
    }
}