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
        
        public void AddClick()
        {
            _progressProvider.PlayerData.ClickData.CountClick++;
        }
    }
}