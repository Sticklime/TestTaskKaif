using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerData
    {
        public ClickData ClickData;
        public LevelData LevelData;
        public PurchasedItemData PurchasedItemData;

        public PlayerData(ClickData clickData, LevelData levelData, PurchasedItemData purchasedItemData)
        {
            ClickData = clickData;
            LevelData = levelData;
            PurchasedItemData = purchasedItemData;
        }
    }
}