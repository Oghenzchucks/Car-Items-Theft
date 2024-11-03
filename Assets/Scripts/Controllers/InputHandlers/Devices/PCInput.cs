using Controllers.InputHandlers.Enums;
using Controllers.InputHandlers.Interfaces;
using Controllers.InputHandlers.Models;
using UnityEngine;

namespace Controllers.InputHandlers.Devices
{
    public class PCInput : IUserInput
    {
        public InputData ProcessInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                return new MouseInputData(MouseInputEnum.LEFT);
            }
            
            if (Input.GetMouseButtonUp(0))
            {
                return new MouseInputData(MouseInputEnum.LEFT, InputPhase.Ended);
            }
            
            if (Input.GetMouseButtonDown(1))
            {
                return new MouseInputData(MouseInputEnum.RIGHT);
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                return new KeyInputData(KeyInputEnum.SPACE);
            }
            
            if (Input.GetKeyUp(KeyCode.Space))
            {
                return new KeyInputData(KeyInputEnum.SPACE, InputPhase.Ended);
            }
            
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                return new KeyInputData(KeyInputEnum.LEFT_ARROW);
            }
            
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                return new KeyInputData(KeyInputEnum.RIGHT_ARROW);
            }
            
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                return new KeyInputData(KeyInputEnum.UP_ARROW);
            }

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                return new KeyInputData(KeyInputEnum.DOWN_ARROW);
            }
            
            return null;
        }
    }
}
