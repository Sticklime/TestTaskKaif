using System.Collections.Generic;
using System.Linq;
using CodeBase.Data.Configs;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.ConfigProvider
{
    public class ConfigProvider : IConfigProvider
    {
        private List<ItemConfig> _itemConfig;
        private StoreItem _storeItem;

        public void Load()
        {
            _itemConfig = Resources.LoadAll<ItemConfig>(PathProvider.ItemDataPath).ToList();
            _storeItem = Resources.Load<StoreItem>(PathProvider.ItemStoreDataPath);
        }

        public ItemConfig GetItemData(ItemType itemType) =>
            _itemConfig.FirstOrDefault(x => x.ItemType == itemType);

        public StoreItem GetStoreItem() =>
            _storeItem;
    }
}