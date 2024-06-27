using CodeBase.Data.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.GameLogic.Item
{
    public class StoreContentView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameItem;
        [SerializeField] private TMP_Text _priceItem;
        [SerializeField] private TMP_Text _buffValue;
        [SerializeField] private Image _imageItem;
        [SerializeField] private Button _buyButton;
        [SerializeField] private BuyItemPresenter _buyItemPresenter;

        private const string PurchasedText = "Purchased";

        public ItemType ItemType { get; private set; }

        private void OnEnable() =>
            _buyButton.onClick.AddListener(_buyItemPresenter.BuyItem);

        private void OnDisable() =>
            _buyButton.onClick.RemoveListener(_buyItemPresenter.BuyItem);

        public void RefreshContent(string nameItem, int priceItem, int buffValue, Sprite spriteItem, ItemType itemType)
        {
            _nameItem.text = nameItem;
            _priceItem.text = priceItem.ToString();
            _buffValue.text = buffValue.ToString();
            _imageItem.sprite = spriteItem;
            ItemType = itemType;
        }

        public void PurchasedSetSlot() =>
            _priceItem.text = PurchasedText;

        public void SetInteractiveButton(bool isInteractive) =>
            _buyButton.interactable = isInteractive;
    }
}