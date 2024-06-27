using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CodeBase.GameLogic.ClickEffect
{
    public class ClickEffectView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _clickForce;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _durationAnimation;
        [SerializeField] private float _heightAnimation;

        private Vector3 _initialPosition;
        private float _initialAlpha;

        private void Awake()
        {
            _initialPosition = transform.position;
            _initialAlpha = _canvasGroup.alpha;
        }

        public void RefreshData(int clickForce)
        {
            _clickForce.text = clickForce.ToString();
        }

        public void ShowAnimation()
        {
            transform.DOMoveY(_initialPosition.y + _heightAnimation, _durationAnimation);
            _canvasGroup.DOFade(0, _durationAnimation).OnComplete(() => gameObject.SetActive(false));
        }

        public void ResetView()
        {
            transform.position = _initialPosition;
            _canvasGroup.alpha = _initialAlpha;
            
        }
    }
}