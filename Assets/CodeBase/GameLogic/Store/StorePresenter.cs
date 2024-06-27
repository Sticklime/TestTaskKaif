using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Data.Configs;
using CodeBase.GameLogic.Item;
using CodeBase.GameLogic.Purchases;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.ConfigProvider;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace CodeBase.GameLogic.Store
{
    public class StorePresenter : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollView;

        private PurchasesHandler _purchasesHandler;
        private IConfigProvider _configProvider;
        private IUIFactory _uiFactory;
        private IProgressProvider _progressProvider;

        [Inject]
        public void Construct(IConfigProvider configProvider, IUIFactory uiFactory, PurchasesHandler purchasesHandler,
            IProgressProvider progressProvider)
        {
            _configProvider = configProvider;
            _uiFactory = uiFactory;
            _purchasesHandler = purchasesHandler;
            _progressProvider = progressProvider;
        }

        private void Start()
        {
            AddContentShop();
        }

        private void AddContentShop()
        {
            StoreItem storeItem = _configProvider.GetStoreItem();

            foreach (var itemType in storeItem.ItemsType)
            {
                ItemConfig itemData = _configProvider.GetItemData(itemType);
                StoreContentView itemView = _uiFactory.CreateStoreContent(_scrollView.content);

                itemView.RefreshContent(itemData.NameItem, itemData.PriceItem, itemData.ClickForced, itemData.IconItem,
                    itemData.ItemType);
                itemView.SetInteractiveButton(_purchasesHandler.CheckCanBuy(itemType));

                if (!_purchasesHandler.HasPurchased(itemView.ItemType, _progressProvider.PlayerData))
                    itemView.PurchasedSetSlot();
            }
        }
    }
}