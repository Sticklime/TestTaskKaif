using CodeBase.Data;
using CodeBase.Services.SaveLoad;

namespace CodeBase.DomainLogic
{
    public class ScoreClick
    {
        private readonly IProgressProvider _progressProvider;
        private readonly ISaveLoadServices _saveLoadServices;

        public ScoreClick(IProgressProvider progressProvider, ISaveLoadServices saveLoadServices)
        {
            _progressProvider = progressProvider;
            _saveLoadServices = saveLoadServices;
        }

        public void AddClick()
        {
            _saveLoadServices.SaveProgress();
            _progressProvider.PlayerData.ClickData.CountClick++;
        }
    }
}