using CodeBase.DomainLogic;
using CodeBase.GameLogic.Purchases;
using UnityEngine;
using VContainer;

namespace CodeBase.GameLogic.ScorePoints
{
    public class ScorePointsPresenter : MonoBehaviour
    {
        [SerializeField] private ScorePointView _scorePointView;

        private PurchasesHandler _purchasesHandler;
        private ScorePoint _scorePoint;

        [Inject]
        public void Construct(ScorePoint scorePoint, PurchasesHandler purchasesHandler)
        {
            _scorePoint = scorePoint;
            _purchasesHandler = purchasesHandler;
        }

        public void OnEnable()
        {
            _scorePoint.AddListenerIsChanged(RefreshData);
            _purchasesHandler.AddListenerIsChanged(RefreshData);

            _scorePointView.RefreshData(_scorePoint.GetCountPoint());
        }

        public void OnDisable()
        {
            _scorePoint.RemoveListenerIsChanged(RefreshData);
            _purchasesHandler.RemoveListenerIsChanged(RefreshData);
        }

        private void RefreshData() =>
            _scorePointView.RefreshData(_scorePoint.GetCountPoint());
    }
}