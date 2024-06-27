using System;
using CodeBase.Data;

namespace CodeBase.DomainLogic
{
    public class LevelHandler : IChangedObserver
    {
        public event Action IsChanged;

        private readonly IProgressProvider _progressProvider;


        public LevelHandler(IProgressProvider progressProvider)
        {
            _progressProvider = progressProvider;
        }

        public void AddListenerIsChanged(Action action) =>
            IsChanged += action;

        public void RemoveListenerIsChanged(Action action) =>
            IsChanged -= action;

        public void AddLevelPoint(int countPoint)
        {
            var levelData = _progressProvider.PlayerData.LevelData;
            levelData.CurrentPointLevel += countPoint;

            TryLevelUp(levelData);

            IsChanged?.Invoke();
        }

        private static void TryLevelUp(LevelData levelData)
        {
            if (levelData.CurrentPointLevel >= levelData.CountPointNextLevel)
            {
                levelData.CurrentLevel++;
                levelData.CurrentPointLevel = 0;

                levelData.CountPointNextLevel *= 2;
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