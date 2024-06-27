using System;
using CodeBase.DomainLogic;
using CodeBase.ObjectPools;
using UnityEngine;
using VContainer;

namespace CodeBase.GameLogic.ClickEffect
{
    public class ClickEffectPresenter : MonoBehaviour
    {
        [SerializeField] private ClickEffectView _clickEffectView;

        private ScorePoint _scorePoint;
        private IObjectPool _objectPool;

        [Inject]
        public void Construct(ScorePoint scorePoint, IObjectPool objectPool)
        {
            _scorePoint = scorePoint;
            _objectPool = objectPool;
        }

        public void OnDisable()
        {
            _clickEffectView.ResetView();
            _objectPool.ReturnToPool(gameObject);
        }

        public void ViewEffect()
        {
            _clickEffectView.RefreshData(_scorePoint.GetCountPointPerClick());
            _clickEffectView.ShowAnimation();
        }
    }
}