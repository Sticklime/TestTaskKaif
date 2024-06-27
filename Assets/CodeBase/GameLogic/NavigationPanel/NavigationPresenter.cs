using CodeBase.Infrastructure.Services.WindowServices;
using UnityEngine;
using VContainer;

namespace CodeBase.DomainLogic.NavigationPanel
{
    public class NavigationPresenter : MonoBehaviour
    {
        [SerializeField] private WindowType _windowType;

        private IWindowServices _windowServices;

        [Inject]
        public void Construct(IWindowServices windowServices)
        {
            _windowServices = windowServices;
        }

        public void OpenWindow()
        {
            _windowServices.OpenWindow(_windowType);
        }
    }
}