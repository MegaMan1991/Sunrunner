using System;
using UnityEngine;
using UnityEngine.InputSystem; // Make sure you import this namespace for the Input System to work.

public class InputHandler : MonoBehaviour
{
    private InputSystem_Actions _inputSystemActions;

    // Events for touch start and touch end
    public event Action<Vector2> TouchStarted;
    public event Action<Vector2> TouchEnded;

    public Vector2 TouchStartPosition { get; private set; }
    public Vector2 TouchCurrentPosition { get; private set; }
    public bool TouchHeld { get; private set; } = false;

    private void Awake()
    {
        _inputSystemActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        // Enable the input actions
        _inputSystemActions.Enable();

        // Subscribe to the performed and canceled events
        _inputSystemActions.Player.TouchPoint.performed += OnTouchPerformed;
        _inputSystemActions.Player.TouchPoint.canceled += OnTouchCancelled;
    }

    private void OnDisable()
    {
        // Unsubscribe from the input events to avoid memory leaks
        _inputSystemActions.Player.TouchPoint.performed -= OnTouchPerformed;
        _inputSystemActions.Player.TouchPoint.canceled -= OnTouchCancelled;

        _inputSystemActions.Disable();
    }

    private void OnTouchPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Touch Performed"); // Use Debug.Log for output
        TouchHeld = true;
        Vector2 TouchPosition = context.ReadValue<Vector2>();
        //save start position
        TouchStartPosition = TouchPosition;
        //update current position - here it's our start
        TouchCurrentPosition = TouchPosition;
        //send event notification for listeners
        TouchStarted?.Invoke(TouchPosition);
        Debug.Log("Touch Start Pos: " +  TouchStartPosition);
    }

    private void OnTouchCancelled(InputAction.CallbackContext context)
    {
        Debug.Log("Release");
        // revert our public bool
        TouchHeld = false;
        // send notification for listeners of last known position
        TouchEnded?.Invoke(TouchCurrentPosition);
        Debug.Log("Touch End Pos: " + TouchCurrentPosition);
        // clear out touch positions when there's no input
        TouchStartPosition = Vector2.zero;
        TouchCurrentPosition = Vector2.zero;
        
    }

    private void Update()
    {
        if (TouchHeld)
        {
            TouchCurrentPosition =
                _inputSystemActions.Player.TouchPoint.ReadValue<Vector2>();
        }
    }

}