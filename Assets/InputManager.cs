using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEditor;
static class InputActions
{
    public static Action jumpReact;
    public static Action jumpDown;
    public static Action interact;
    public static Action q;
}
public class InputManager : MonoBehaviour, GameInput.IGameplayActions
{
    public GameInput gameInput;
    public GameObject player;
    public GameObject interacter;
    public Renderer qObject;
    void Start()
    {
        
        gameInput = new GameInput();
        gameInput.Gameplay.SetCallbacks(this);
        gameInput.Gameplay.Enable();
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            moveBoxOut();
        }
        if (context.canceled)
        {
            moveBoxIn();
        }
    }
    public void OnQ(InputAction.CallbackContext context)
    { 
        if (context.started)
        {
            InputActions.q += Qstarted;
            InputActions.q?.Invoke();
            InputActions.q -= Qstarted;
        }
        if (context.performed)
        {
            InputActions.q += Qperformed;
            InputActions.q?.Invoke();
            InputActions.q -= Qperformed;
        }
        if (context.canceled)
        {
            InputActions.q += Qcanceled;
            InputActions.q?.Invoke();
            InputActions.q -= Qcanceled;
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            InputActions.jumpDown -= jumpDown;
            InputActions.jumpReact += jumpUp;
            InputActions.jumpReact?.Invoke();
        }
        if (context.canceled)
        {
            InputActions.jumpReact -= jumpUp;
            InputActions.jumpDown += jumpDown;
            InputActions.jumpDown?.Invoke();
        }

    }
    public void moveBoxOut()
    {
        interacter.SetActive(false);
    }
    public void moveBoxIn()
    {
        interacter.SetActive(true);
    }
    public void jumpUp()
    {
        player.transform.position += new Vector3(0, 2, 0);
    }
    public void jumpDown()
    {
        player.transform.position -= new Vector3(0, 2, 0);
    }
    public void Qstarted()
    {
        qObject.material.color = Color.blue;
    }
    public void Qperformed()
    {
        qObject.material.color = Color.green;
    }
    public void Qcanceled()
    {
        qObject.material.color = Color.red;
    }
}
