using System.Collections.Generic;
using Controllers.GamePlay;
using UnityEngine;

namespace Scriptable.ControlSystemsData
{
    [CreateAssetMenu(fileName = "ControlSystemData", menuName = "Game/ControlSystem")]
    public class ControlSystemData : ScriptableObject
    {
        public List<GameControlSystemData> gameControlSystemData = new();
    }
}
