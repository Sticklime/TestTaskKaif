using CodeBase.DomainLogic.ScoreClicker;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.DomainLogic
{
    public class ClickerButtonView : MonoBehaviour
    {
        [SerializeField] private ScoreClickPresenter _scoreClickPresenter;
        [SerializeField] private Button _clickButton;

        private void OnEnable()
        {
            _clickButton.onClick.AddListener(_scoreClickPresenter.OnButtonClicked);
        }

        private void OnDisable()
        {
            _clickButton.onClick.RemoveListener(_scoreClickPresenter.OnButtonClicked);
        }
    }
}