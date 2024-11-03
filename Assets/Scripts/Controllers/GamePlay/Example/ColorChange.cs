using Controllers.InputHandlers;
using Controllers.InputHandlers.Enums;
using Controllers.InputHandlers.Interfaces;
using Controllers.InputHandlers.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.GamePlay
{
    public class ColorChange : MonoBehaviour, IInputListener
    {
        [SerializeField] private Image image;
        private bool _hasChanged;

        private void Awake()
        {
            InputActionHandler.AddListener(this);
        }

        private void OnDestroy()
        {
            InputActionHandler.RemoveListener(this);
        }

        public void OnInputFired(InputData inputData)
        {
            switch (inputData.InputEnum)
            {
                case InputEnum.KEY:
                    var keyInputData = (KeyInputData)inputData;
                    if (keyInputData.KeyInputEnum == KeyInputEnum.SPACE && keyInputData.InputPhase == InputPhase.Began)
                    {
                        ChangeColor();
                    }
                    break;
                case InputEnum.CANVAS:
                    var canvasInputData = (CanvasInputData)inputData;
                    if (canvasInputData.CanvasInputEnum == CanvasInputEnum.MOVE_UP)
                    {
                        ChangeColor();
                    }
                    break;
            }
        }

        private void ChangeColor()
        {
            image.color = _hasChanged ? Color.blue : Color.green;
            _hasChanged = !_hasChanged;
        }
    }
}
