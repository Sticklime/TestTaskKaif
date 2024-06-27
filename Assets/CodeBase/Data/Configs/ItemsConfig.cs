using UnityEngine;

namespace CodeBase.Data.Configs
{
    [CreateAssetMenu(menuName = "ItemConfig", fileName = "NewItemConfig")]
    public class ItemConfig : ScriptableObject
    {
        [field: SerializeField] public string NameItem { get; private set; }
        [field: SerializeField] public Sprite IconItem { get; private set; }
        [field: SerializeField] public ItemType ItemType { get; private set; }
        [field: SerializeField] public int PriceItem { get; private set; }
        [field: SerializeField] public int ClickForced { get; private set; }
    }
}