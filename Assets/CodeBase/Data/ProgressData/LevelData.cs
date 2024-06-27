using System;

namespace CodeBase.Data
{
    [Serializable]
    public class LevelData
    {
        public int CurrentLevel;
        public int CurrentPointLevel;
        public int CountPointNextLevel;

        public LevelData(int currentLevel, int currentPointLevel, int countPointNextLevel)
        {
            CurrentLevel = currentLevel;
            CurrentPointLevel = currentPointLevel;
            CountPointNextLevel = countPointNextLevel;
        }
    }
}