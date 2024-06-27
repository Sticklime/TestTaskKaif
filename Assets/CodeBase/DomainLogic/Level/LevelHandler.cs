using System;
using CodeBase.Data;

namespace CodeBase.DomainLogic
{
    public class LevelHandler : IChangedObserver
    {
        private readonly IProgressProvider _progressProvider;

        private event Action _isChangedLevel;

        public LevelHandler(IProgressProvider progressProvider)
        {
            _progressProvider = progressProvider;
        }

        public void AddListenerIsChanged(Action action) =>
            _isChangedLevel += action;

        public void RemoveListenerIsChanged(Action action) =>
            _isChangedLevel -= action;

        public void AddLevelPoint(int countPoint)
        {
            var levelData = _progressProvider.PlayerData.LevelData;
            levelData.CurrentPointLevel += countPoint;
            
            TryLevelUp(levelData);
            
            _isChangedLevel?.Invoke();
        }

        private static void TryLevelUp(LevelData levelData)
        {
            if (levelData.CurrentPointLevel >= levelData.CountPointNextLevel)
            {
                levelData.CurrentLevel++;
                levelData.CurrentPointLevel = 0;

                levelData.CountPointNextLevel += 10;
            }
        }

        public int GetCurrentLevel() =>
            _progressProvider.PlayerData.LevelData.CurrentLevel;

        public int GetCurrentPointLevel() =>
            _progressProvider.PlayerData.LevelData.CurrentPointLevel;

        public int GetCountPointNextLevel() =>
            _progressProvider.PlayerData.LevelData.CountPointNextLevel;
    }
}