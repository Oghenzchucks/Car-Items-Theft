using Controllers.InputHandlers.Enums;
using Controllers.InputHandlers.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.InputHandlers.Canvas
{
    [RequireComponent(typeof(Button))]
    public class ButtonInput : MonoBehaviour
    {
        [SerializeField] private CanvasInputEnum canvasInputEnum;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            InputActionHandler.FireListeners(new CanvasInputData(canvasInputEnum));
        }
    }
}
