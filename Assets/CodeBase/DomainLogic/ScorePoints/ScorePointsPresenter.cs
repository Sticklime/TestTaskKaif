using UnityEngine;
using VContainer;

namespace CodeBase.DomainLogic.ScorePoints
{
    public class ScorePointsPresenter : MonoBehaviour
    {
        [SerializeField] private ScorePointView _scorePointView;

        private ScorePoint _scorePoint;

        [Inject]
        public void Construct(ScorePoint scorePoint)
        {
            _scorePoint = scorePoint;
        }

        public void OnEnable() =>
            _scorePoint.AddListenerIsChanged(RefreshData);

        public void OnDisable() =>
            _scorePoint.RemoveListenerIsChanged(RefreshData);

        private void RefreshData() =>
            _scorePointView.RefreshData(_scorePoint.GetCountPoint());
    }
}