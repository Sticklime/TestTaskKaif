using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.DomainLogic
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currentLevelText;
        [SerializeField] private Image _progressFillAmount;

        public void RefreshData(int currentLevel, int currentPointLevel, int pointNextLevel)
        {
            _currentLevelText.text = currentLevel.ToString();

            RefreshProgressImage(currentPointLevel, pointNextLevel);
        }

        private void RefreshProgressImage(int currentPointLevel, int pointNextLevel) =>
            _progressFillAmount.fillAmount = (float)currentPointLevel / pointNextLevel;
    }
}