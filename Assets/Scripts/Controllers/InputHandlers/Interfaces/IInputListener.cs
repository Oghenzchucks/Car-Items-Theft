using Controllers.InputHandlers.Models;

namespace Controllers.InputHandlers.Interfaces
{
    public interface IInputListener
    {
        public void OnInputFired(InputData inputData);
    }
}
