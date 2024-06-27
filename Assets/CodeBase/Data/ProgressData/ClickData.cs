using System;

namespace CodeBase.Data
{
    [Serializable]
    public class ClickData
    {
        public int CountClick;
        public int CountPoint;
        public int ForceClick;

        public ClickData(int countClick, int countPoint, int forceClick)
        {
            CountClick = countClick;
            CountPoint = countPoint;
            ForceClick = forceClick;
        }
    }
}