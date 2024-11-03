using System;

namespace Controllers.GamePlay
{
    [Serializable]
    public struct GameControlSystemData
    {
        public string id;
        public float forwardRate, backwardRate, maxAmount;
    }
}