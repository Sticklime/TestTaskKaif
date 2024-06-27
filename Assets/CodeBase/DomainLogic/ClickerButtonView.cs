using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace CodeBase.DomainLogic
{
    public class ClickerButtonView : MonoBehaviour
    {
        [SerializeField] private ScoreClickPresenter _scoreClickPresenter;
        [SerializeField] private LevelPresenter _levelPresenter;
        [SerializeField] private Button _clickButton;

        private void OnEnable()
        {
            _clickButton.onClick.AddListener(_scoreClickPresenter.OnButtonClicked);
            _clickButton.onClick.AddListener(_levelPresenter.ChangeLevel);
        }

        private void OnDisable()
        {
            _clickButton.onClick.RemoveListener(_scoreClickPresenter.OnButtonClicked);
            _clickButton.onClick.RemoveListener(_levelPresenter.ChangeLevel);
        }
    }
}