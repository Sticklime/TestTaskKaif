using CodeBase.DomainLogic;
using UnityEngine;
using VContainer;

namespace CodeBase.GameLogic.Level
{
    public class LevelPresenter : MonoBehaviour
    {
        [SerializeField] private LevelView _levelView;

        private LevelHandler _levelHandler;

        [Inject]
        public void Construct(LevelHandler levelHandler)
        {
            _levelHandler = levelHandler;
        }

        public void OnEnable()
        {
            _levelHandler.AddListenerIsChanged(RefreshLevel);
            
            RefreshLevel();
        }

        public void OnDisable()
        {
            _levelHandler.RemoveListenerIsChanged(RefreshLevel);
        }

        private void RefreshLevel()
        {
            var currentLevel = _levelHandler.GetCurrentLevel();
            var currentPointLevel = _levelHandler.GetCurrentPointLevel();
            var currentPointNextLevel = _levelHandler.GetCountPointNextLevel();
            float percentageValue = (float)currentPointLevel / currentPointNextLevel;

            _levelView.RefreshData(currentLevel, percentageValue);
        }
    }
}