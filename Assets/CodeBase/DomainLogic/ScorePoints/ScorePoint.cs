using System;
using CodeBase.Data;

namespace CodeBase.DomainLogic
{
    public class ScorePoint : IChangedObserver
    {
        private readonly IProgressProvider _progressProvider;

        private event Action IsChangedPoint;

        public ScorePoint(IProgressProvider progressProvider)
        {
            _progressProvider = progressProvider;
        }

        public void AddListenerIsChanged(Action action) =>
            IsChangedPoint += action;

        public void RemoveListenerIsChanged(Action action) =>
            IsChangedPoint -= action;

        public int GetCountPoint() =>
            _progressProvider.PlayerData.ClickData.CountPoint;

        public int GetCountPointPerClick() => 1;

        public void AddPoint()
        {
            _progressProvider.PlayerData.ClickData.CountPoint++;

            IsChangedPoint?.Invoke();
        }
    }
}