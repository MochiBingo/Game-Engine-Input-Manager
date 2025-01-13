using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEditor;

public class inputManager : MonoBehaviour, GameInput.IGameplayActions
{
    public GameInput gameInput;

    public void Start()
    {
        gameInput = new GameInput();
        gameInput.Gameplay.SetCallbacks(this);
        gameInput.Gameplay.Enable();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InputActions.jumpEventStarted?.Invoke();
        }
        if (context.canceled)
        {
            InputActions.jumpEventCanceled?.Invoke();
        }

    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InputActions.interactEventStarted?.Invoke();
        }
        if (context.canceled)
        {
            InputActions.interactEventCanceled?.Invoke();
        }
    }
    public void OnQ(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InputActions.qEventStarted?.Invoke();
        }
        if (context.performed)
        {
            InputActions.qEventPerformed?.Invoke();
        }
        if (context.canceled)
        {
            InputActions.qEventCanceled?.Invoke();
        }
    }
}
