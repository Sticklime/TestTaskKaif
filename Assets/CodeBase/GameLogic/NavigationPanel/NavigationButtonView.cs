using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.DomainLogic.NavigationPanel
{
    public class NavigationButtonView : MonoBehaviour
    {
        [SerializeField] private NavigationPresenter _navigationPresenter;
        [SerializeField] private Button _windowButton;

        private void OnEnable() =>
            _windowButton.onClick.AddListener(_navigationPresenter.OpenWindow);

        private void OnDisable() =>
            _windowButton.onClick.RemoveListener(_navigationPresenter.OpenWindow);
    }
}