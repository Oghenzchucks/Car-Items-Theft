using System.Collections.Generic;
using Scriptable.ControlSystemsData;
using UnityEngine;

namespace Controllers.GamePlay
{
    public class GameControlSystem : MonoBehaviour
    {
        [SerializeField] private ControlSystemData controlSystemData;
        [SerializeField] private List<DisplaySystem> displaySystems = new();
        
        private Dictionary<string, ControlSystem> _controlSystems;

        private void Start()
        {
            _controlSystems = new Dictionary<string, ControlSystem>();

            foreach (var data in controlSystemData.gameControlSystemData)
            {
                var controlSystemId = data.id;
                displaySystems.Add(new DisplaySystem(controlSystemId));
                _controlSystems.Add(controlSystemId, new ControlSystem(data));
            }

            foreach (var item in _controlSystems)
            {
                item.Value.Start(true);
            }
        }

        private void Update()
        {
            foreach (var item in _controlSystems)
            {
                item.Value.Update();
                var displaySystem = displaySystems.Find(x => x.id == item.Key);
                displaySystem.ShowDisplay(item.Value);
            }
        }
    }
}
