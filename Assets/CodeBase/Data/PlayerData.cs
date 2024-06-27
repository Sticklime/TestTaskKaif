using System;
using UnityEngine;

namespace CodeBase.Data
{
    public class ProgressProvider : IProgressProvider
    {
        public PlayerData PlayerData { get; set; }
    }

    public interface IProgressProvider
    {
        PlayerData PlayerData { get; set; }
    }

    [Serializable]
    public class PlayerData
    {
        public ClickData ClickData;
        public LevelData LevelData;

        public PlayerData(ClickData clickData, LevelData levelData)
        {
            ClickData = clickData;
            LevelData = levelData;
        }
    }

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

    [Serializable]
    public class ClickData
    {
        public int CountClick;
        public int CountPoint;

        public ClickData(int countClick, int countPoint)
        {
            CountClick = countClick;
            CountPoint = countPoint;
        }
    }
}