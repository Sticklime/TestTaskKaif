using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.DomainLogic
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currentLevelText;
        [SerializeField] private Image _progressFillAmount;

        public void RefreshData(int currentLevel, float percentageValue)
        {
            _currentLevelText.text = currentLevel.ToString();

            RefreshProgressImage(percentageValue);
        }

        private void RefreshProgressImage(float percentageValue) =>
            _progressFillAmount.fillAmount = percentageValue;
    }
}