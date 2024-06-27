using CodeBase.Data.Configs;

namespace CodeBase.Infrastructure.Services.ConfigProvider
{
    public interface IConfigProvider
    {
        void Load();
        ItemConfig GetItemData(ItemType itemType);
        StoreItem GetStoreItem();
    }
}