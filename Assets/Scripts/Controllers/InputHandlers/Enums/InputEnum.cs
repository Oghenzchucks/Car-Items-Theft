namespace Controllers.InputHandlers.Enums
{
    public enum InputEnum 
    {
        NONE,
        TOUCH, 
        MOUSE,
        KEY,
        CANVAS,
    }
    
    public enum KeyInputEnum
    {
        SPACE,
        LEFT_ARROW,
        RIGHT_ARROW,
        UP_ARROW,
        DOWN_ARROW,
    }
    
    public enum MouseInputEnum
    {
        NONE,
        LEFT,
        RIGHT,
    }

    public enum CanvasInputEnum
    {
        NONE,
        MOVE_LEFT,
        MOVE_RIGHT,
        MOVE_UP,
        MOVE_DOWN,
    }

    public enum InputPhase
    {
        /// <summary>
        ///   <para>A finger touched the screen.</para>
        /// </summary>
        Began,
        /// <summary>
        ///   <para>A finger moved on the screen.</para>
        /// </summary>
        Moved,
        /// <summary>
        ///   <para>A finger is touching the screen but hasn't moved.</para>
        /// </summary>
        Stationary,
        /// <summary>
        ///   <para>A finger was lifted from the screen. This is the final phase of a touch.</para>
        /// </summary>
        Ended,
        /// <summary>
        ///   <para>The system cancelled tracking for the touch.</para>
        /// </summary>
        Canceled,
    }
}
