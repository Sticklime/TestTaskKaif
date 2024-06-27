using System;
using CodeBase.Data.Configs;

namespace CodeBase.Data
{
    [Serializable]
    public class ItemData
    {
        public ItemType ItemType;
        public int ForcedClick;

        public ItemData(ItemType itemType, int forcedClick)
        {
            ItemType = itemType;
            ForcedClick = forcedClick;
        }
    }
}