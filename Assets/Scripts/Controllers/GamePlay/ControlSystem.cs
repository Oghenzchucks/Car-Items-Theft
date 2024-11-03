using UnityEngine;

namespace Controllers.GamePlay
{
    public class ControlSystem
    {
        public float CurrentAmount { get; private set; }
        public bool IsActive { get; private set; }
        private readonly GameControlSystemData _gameControlSystemData;
        private bool _isForwardDirection;

        public ControlSystem(GameControlSystemData gameControlSystemData)
        {
            _gameControlSystemData = gameControlSystemData;
        }

        public void Update()
        {
            if (!IsActive)
            {
                return;
            }
            
            if (_isForwardDirection)
            {
                CurrentAmount += _gameControlSystemData.forwardRate * Time.deltaTime;

                if (CurrentAmount >= _gameControlSystemData.maxAmount)
                {
                    IsActive = false;
                    CurrentAmount = _gameControlSystemData.maxAmount;
                }
            }
            else
            {
                CurrentAmount -= _gameControlSystemData.backwardRate * Time.deltaTime;

                if (CurrentAmount <= 0)
                {
                    IsActive = false;
                    CurrentAmount = 0;
                }
            }
        }
        
        public void Start(bool isForwardDirection, float currentAmount = 0)
        {
            _isForwardDirection = isForwardDirection;
            CurrentAmount = currentAmount;
            IsActive = true;
        }
    }
}
