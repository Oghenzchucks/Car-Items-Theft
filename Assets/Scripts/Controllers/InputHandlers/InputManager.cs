using Controllers.InputHandlers.Devices;
using Controllers.InputHandlers.Interfaces;
using UnityEngine;

namespace Controllers.InputHandlers
{
    public class InputManager : MonoBehaviour
    {
        private IUserInput _deviceInput;

        private void Start()
        {
#if UNITY_STANDALONE || UNITY_WEBGL
            _deviceInput = new PCInput();
#elif UNITY_IOS || UNITY_ANDROID
            userInput = new MobileInput();
#endif
        }

        private void Update()
        {
            var inputData = _deviceInput.ProcessInput();
            if (inputData != null)
            {
                InputActionHandler.FireListeners(inputData);
            }
        }
    }
}
