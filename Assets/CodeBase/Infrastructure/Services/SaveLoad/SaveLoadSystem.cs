using CodeBase.Data;
using UnityEngine;

namespace CodeBase.Services.SaveLoad
{
    public class SaveLoadServices : ISaveLoadServices
    {
        private const string ProgressKey = "Progress";

        private readonly IProgressProvider _progressService;

        public SaveLoadServices(IProgressProvider progressProvider)
        {
            _progressService = progressProvider;
        }

        public void SaveProgress() =>
            PlayerPrefs.SetString(ProgressKey, JsonUtility.ToJson(_progressService.PlayerData));

        public PlayerData LoadProgress() =>
            JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString(ProgressKey));
    }
}