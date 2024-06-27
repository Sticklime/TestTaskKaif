using CodeBase.Data;
using CodeBase.Data.Configs;
using CodeBase.GameLogic.Purchases;
using CodeBase.Infrastructure.Services.ConfigProvider;
using UnityEngine;
using VContainer;

namespace CodeBase.GameLogic.Item
{
    public class BuyItemPresenter : MonoBehaviour
    {
        [SerializeField] private StoreContentView _storeContentView;

        private PurchasesHandler _purchasesHandler;
        private IProgressProvider _progressProvider;
        private IConfigProvider _configProvider;

        [Inject]
        public void Construct(PurchasesHandler purchasesHandler, IProgressProvider progressProvider,
            IConfigProvider configProvider)
        {
            _purchasesHandler = purchasesHandler;
            _progressProvider = progressProvider;
            _configProvider = configProvider;
        }

        private void OnEnable()
        {
            _purchasesHandler.AddListenerIsChanged(RefreshBuyButton);

            if (_storeContentView.ItemType != ItemType.Default)
                RefreshBuyButton();

            SetPurchased();
        }

        private void OnDisable()
        {
            _purchasesHandler.RemoveListenerIsChanged(RefreshBuyButton);
        }

        public void BuyItem() =>
            _purchasesHandler.BuyItem(_storeContentView.ItemType);

        private void RefreshBuyButton()
        {
            _storeContentView.SetInteractiveButton(_purchasesHandler.CheckCanBuy(_storeContentView.ItemType));

            SetPurchased();
        }

        private void SetPurchased()
        {
            if (!_purchasesHandler.HasPurchased(_storeContentView.ItemType, _progressProvider.PlayerData))
                _storeContentView.PurchasedSetSlot();
        }
    }
}