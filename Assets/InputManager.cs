using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviour, GameInput.IGameplayActions
{
    public GameInput gameInput;
    void Start()
    {
        
        gameInput = new GameInput();
        gameInput.Gameplay.SetCallbacks(this);
        gameInput.Gameplay.Enable();
    }
    #region Public Actions

    private Action JumpEvent;

    #endregion

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jump");
        }
    }
}
