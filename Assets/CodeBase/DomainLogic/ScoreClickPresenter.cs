using UnityEngine;
using VContainer;

namespace CodeBase.DomainLogic
{
    public class ScoreClickPresenter : MonoBehaviour
    {
        [SerializeField] private LevelView _levelView;

        private LevelHandler _levelHandler;
        private ScorePoint _scorePoint;
        private ScoreClick _scoreClick;

        [Inject]
        public void Construct(ScorePoint scorePoint, LevelHandler levelHandler, ScoreClick scoreClick)
        {
            _scorePoint = scorePoint;
            _levelHandler = levelHandler;
            _scoreClick = scoreClick;
        }

        public void OnButtonClicked()
        {
            _scoreClick.AddClick();
            _scorePoint.AddPoint();

            _levelHandler.AddLevelPoint(_scorePoint.GetCountPointPerClick());
        }
    }
}