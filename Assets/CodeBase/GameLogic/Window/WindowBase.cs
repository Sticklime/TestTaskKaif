using CodeBase.Infrastructure.Services.WindowServices;
using UnityEngine;

namespace CodeBase
{
    public abstract class WindowBase : MonoBehaviour
    {
        [field: SerializeField] public WindowType WindowType { get; private set; }

        public virtual void Open()
        {
            gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
    }
}