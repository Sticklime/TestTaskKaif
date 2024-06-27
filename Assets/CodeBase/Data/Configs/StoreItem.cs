using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Data.Configs
{
    [CreateAssetMenu(menuName = "StoreItem", fileName = "NewStoreItem")]
    public class StoreItem : ScriptableObject
    {
        [field: SerializeField] public List<ItemType> ItemsType { get; private set; }
    }
}