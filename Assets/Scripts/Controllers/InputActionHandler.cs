using System.Collections.Generic;
using Controllers.InputHandlers;
using Controllers.InputHandlers.Interfaces;
using Controllers.InputHandlers.Models;

namespace Controllers
{
    public static class InputActionHandler
    {
        private static readonly List<IInputListener> InputListeners = new();
        
        public static void AddListener(IInputListener inputListener)
        {
            InputListeners.Add(inputListener);
        }
        
        public static void RemoveListener(IInputListener inputListener)
        {
            if (InputListeners.Count <= 0 || InputListeners.Contains(inputListener))
            {
                return;
            }
            
            InputListeners.Remove(inputListener);
        }

        public static void FireListeners(InputData inputData)
        {
            foreach (var inputListener in InputListeners)
            {
                inputListener.OnInputFired(inputData);
            }
        }
    }
}
