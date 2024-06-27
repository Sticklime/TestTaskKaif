using UnityEngine;
using VContainer;

namespace CodeBase.DomainLogic.Level
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

        public void OnEnable() => 
            _levelHandler.AddListenerIsChanged(ChangeLevel);

        public void OnDisable() => 
            _levelHandler.RemoveListenerIsChanged(ChangeLevel);

        private void ChangeLevel()
        {
            var currentLevel = _levelHandler.GetCurrentLevel();
            var currentPointLevel = _levelHandler.GetCurrentPointLevel();
            var currentPointNextLevel = _levelHandler.GetCountPointNextLevel();

            _levelView.RefreshData(currentLevel, currentPointLevel, currentPointNextLevel);
        }
    }
}