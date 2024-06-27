using CodeBase.DomainLogic;
using CodeBase.GameLogic.ClickEffect;
using CodeBase.ObjectPools;
using UnityEngine;
using VContainer;

namespace CodeBase.GameLogic.ScoreClicker
{
    public class ScoreClickPresenter : MonoBehaviour
    {
        [SerializeField] private LevelView _levelView;

        private LevelHandler _levelHandler;
        private ScorePoint _scorePoint;
        private ScoreClick _scoreClick;
        private IObjectPool _objectPool;

        [Inject]
        public void Construct(ScorePoint scorePoint, LevelHandler levelHandler, ScoreClick scoreClick,
            IObjectPool objectPool)
        {
            _scorePoint = scorePoint;
            _levelHandler = levelHandler;
            _scoreClick = scoreClick;
            _objectPool = objectPool;
        }

        public void OnButtonClicked()
        {
            _scoreClick.AddClick();
            _scorePoint.AddPoint();
            GameObject effectClick = _objectPool.GetPool();
            effectClick.GetComponent<ClickEffectPresenter>().ViewEffect();

            _levelHandler.AddLevelPoint(_scorePoint.GetCountPointPerClick());
        }
    }
}