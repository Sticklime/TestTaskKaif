using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.State;
using CodeBase.Services.SaveLoad;

namespace CodeBase
{
    public class LoadProgressState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IProgressProvider _progressProvider;
        private readonly ISaveLoadServices _saveLoadServices;

        public LoadProgressState(IGameStateMachine gameStateMachine, IProgressProvider progressProvider, ISaveLoadServices saveLoadServices)
        {
            _gameStateMachine = gameStateMachine;
            _progressProvider = progressProvider;
            _saveLoadServices = saveLoadServices;
        }

        public void Enter()
        {
            _progressProvider.PlayerData = _saveLoadServices.LoadProgress() ?? GetNewData();

            _gameStateMachine.Enter<LoadGameState>();
        }

        private PlayerData GetNewData()
        {
            var clickData = new ClickData(0, 0, 1);
            var levelData = new LevelData(0, 0, 10);
            var purchasedItem = new PurchasedItemData(new List<ItemData>());

            return new PlayerData(clickData, levelData, purchasedItem);
        }

        public void Exit()
        {
        }
    }
}