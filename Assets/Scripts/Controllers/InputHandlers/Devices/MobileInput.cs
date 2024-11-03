using System.Collections.Generic;
using Controllers.InputHandlers.Interfaces;
using Controllers.InputHandlers.Models;
using UnityEngine;

namespace Controllers.InputHandlers.Devices
{
    public class MobileInput : IUserInput
    {
        public InputData ProcessInput()
        {
            var touchCounts = Input.touchCount;
            if (touchCounts <= 0)
            {
                return null;
            }

            var touchData = new List<Touch>();
            for (int i = 0; i < touchCounts; i++)
            {
                touchData.Add(Input.GetTouch(i));
            }

            var touchInputData = new TouchInputData(touchData);
            return touchInputData;
        }
    }
}
