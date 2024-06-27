using System;
using System.Linq;
using CodeBase.Data;
using CodeBase.Data.Configs;
using CodeBase.Infrastructure.Services.ConfigProvider;
using CodeBase.Infrastructure.Services.WindowServices;
using CodeBase.Services.SaveLoad;
using VContainer;

namespace CodeBase.GameLogic.Purchases
{
    public class PurchasesHandler : IChangedObserver
    {
        private IProgressProvider _progressProvider;
        private IConfigProvider _configProvider;
        private IWindowServices _windowServices;
        private ISaveLoadServices _saveLoadServices;

        public event Action IsChanged;

        [Inject]
        public void Construct(IProgressProvider progressProvider, IConfigProvider configProvider,
            IWindowServices windowServices, ISaveLoadServices saveLoadServices)
        {
            _progressProvider = progressProvider;
            _configProvider = configProvider;
            _windowServices = windowServices;
            _saveLoadServices = saveLoadServices;
        }

        public void BuyItem(ItemType itemType)
        {
            ItemConfig itemData = _configProvider.GetItemData(itemType);
            PlayerData playerData = _progressProvider.PlayerData;

            if (!CheckCanBuy(itemType))
                return;

            playerData.ClickData.CountPoint -= itemData.PriceItem;
            playerData.PurchasedItemData.ItemData.Add(new ItemData(itemType, itemData.ClickForced));
            _windowServices.OpenWindow(WindowType.ClickerWindow);
            _saveLoadServices.SaveProgress();

            IsChanged?.Invoke();
        }

        public bool CheckCanBuy(ItemType itemType)
        {
            ItemConfig itemData = _configProvider.GetItemData(itemType);
            PlayerData playerData = _progressProvider.PlayerData;

            return CheckPrice(playerData, itemData) &&
                   HasPurchased(itemType, playerData);
        }

        public bool HasPurchased(ItemType itemType, PlayerData playerData) => 
            playerData.PurchasedItemData.ItemData.All(x => x.ItemType != itemType);

        private static bool CheckPrice(PlayerData playerData, ItemConfig itemData) => 
            playerData.ClickData.CountPoint >= itemData.PriceItem;

        public void AddListenerIsChanged(Action action) =>
            IsChanged += action;

        public void RemoveListenerIsChanged(Action action) =>
            IsChanged -= action;
    }
}