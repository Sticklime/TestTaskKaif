using System;
using System.Collections.Generic;

namespace CodeBase.Data
{
    [Serializable]
    public class PurchasedItemData
    {
        public List<ItemData> ItemData;

        public PurchasedItemData(List<ItemData> itemData)
        {
            ItemData = itemData;
        }
    }
}