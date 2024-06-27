using CodeBase.Data;

namespace CodeBase.Services.SaveLoad
{
    public interface ISaveLoadServices
    {
        void SaveProgress();
        PlayerData LoadProgress();
    }
}