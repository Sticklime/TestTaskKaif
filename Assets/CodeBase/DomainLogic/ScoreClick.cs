using CodeBase.Data;

namespace CodeBase.DomainLogic
{
    public class ScoreClick
    {
        private readonly IProgressProvider _progressProvider;

        public ScoreClick(IProgressProvider progressProvider)
        {
            _progressProvider = progressProvider;
        }
        
        public int GetCountClick() =>
            _progressProvider.PlayerData.ClickData.CountClick;
        
        public void AddClick()
        {
            _progressProvider.PlayerData.ClickData.CountClick++;
        }
    }
}