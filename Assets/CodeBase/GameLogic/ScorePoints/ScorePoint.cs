using System;
using CodeBase.Data;

namespace CodeBase.DomainLogic
{
    public class ScorePoint : IChangedObserver
    {
        public event Action IsChanged;

        private readonly IProgressProvider _progressProvider;

        public ScorePoint(IProgressProvider progressProvider)
        {
            _progressProvider = progressProvider;
        }

        public void AddListenerIsChanged(Action action) =>
            IsChanged += action;

        public void RemoveListenerIsChanged(Action action) =>
            IsChanged -= action;

        public int GetCountPoint() =>
            _progressProvider.PlayerData.ClickData.CountPoint;

        public void AddPoint()
        {
            _progressProvider.PlayerData.ClickData.CountPoint += GetCountPointPerClick();

            IsChanged?.Invoke();
        }

        public int GetCountPointPerClick()
        {
            PlayerData playerData = _progressProvider.PlayerData;

            int passiveImprovement = 0;

            foreach (var item in playerData.PurchasedItemData.ItemData)
                passiveImprovement += item.ForcedClick;

            return _progressProvider.PlayerData.ClickData.ForceClick + passiveImprovement;
        }
    }
}