using CodeBase.Data;

namespace CodeBase.DomainLogic
{
    public class ScorePoint
    {
        private readonly IProgressProvider _progressProvider;

        public ScorePoint(IProgressProvider progressProvider)
        {
            _progressProvider = progressProvider;
        }
        
        public int GetCountPoint() =>
            _progressProvider.PlayerData.ClickData.CountPoint;

        public int GetCountPointPerClick() => 
            1;

        public void AddPoint() => 
            _progressProvider.PlayerData.ClickData.CountClick++;
    }
}