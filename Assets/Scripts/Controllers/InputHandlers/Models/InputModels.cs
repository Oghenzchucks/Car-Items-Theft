using System.Collections.Generic;
using Controllers.InputHandlers.Enums;
using UnityEngine;

namespace Controllers.InputHandlers.Models
{
    public abstract class InputData
    {
        public InputEnum InputEnum { get; protected set; }
        public InputPhase InputPhase { get; protected set; }

        protected InputData(InputEnum inputEnum, InputPhase inputPhase = InputPhase.Began)
        {
            InputEnum = inputEnum;
            InputPhase = inputPhase;
        }
    }

    public class TouchInputData : InputData
    {
        public List<Touch> TouchData { get; }

        public TouchInputData(List<Touch> touchData) : base(InputEnum.TOUCH)
        {
            TouchData = touchData;
        }
    }

    public class MouseInputData : InputData
    {
        public MouseInputEnum MouseInputEnum { get; }

        public MouseInputData(MouseInputEnum mouseInputEnum, InputPhase inputPhase = InputPhase.Began) 
            : base(InputEnum.MOUSE, inputPhase)
        {
            MouseInputEnum = mouseInputEnum;
        }
    }

    public class KeyInputData : InputData
    {
        public KeyInputEnum KeyInputEnum { get; }

        public KeyInputData(KeyInputEnum keyInputEnum, InputPhase inputPhase = InputPhase.Began) 
            : base(InputEnum.KEY, inputPhase)
        {
            KeyInputEnum = keyInputEnum;
        }
    }

    public class CanvasInputData : InputData
    {
        public CanvasInputEnum CanvasInputEnum { get; }

        public CanvasInputData(CanvasInputEnum canvasInputEnum, InputPhase inputPhase = InputPhase.Began) 
            : base(InputEnum.CANVAS, inputPhase)
        {
            CanvasInputEnum = canvasInputEnum;
        }
    }
}