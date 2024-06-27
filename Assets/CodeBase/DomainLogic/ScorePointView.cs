using TMPro;
using UnityEngine;

namespace CodeBase.DomainLogic
{
    public class ScorePointView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _countPointText;
        
        public void RefreshData(int countPoint)
        {
            _countPointText.text = countPoint.ToString();
        }
    }
}