using System;

namespace Controllers.GamePlay
{
    [Serializable]
    public class DisplaySystem
    {
        public string id;
        public float currentAmount;
        public bool isActive;

        public DisplaySystem(string systemId)
        {
            id = systemId;
        }

        public void ShowDisplay(ControlSystem controlSystem)
        {
            currentAmount = controlSystem.CurrentAmount;
            isActive = controlSystem.IsActive;
        }
    }
}