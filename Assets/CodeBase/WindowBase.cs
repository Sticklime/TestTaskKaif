using CodeBase.Infrastructure.Services.WindowServices;
using UnityEngine;

namespace CodeBase
{
    public class WindowBase : MonoBehaviour
    {
        [field: SerializeField] public WindowType WindowType { get; private set; }
    }
}