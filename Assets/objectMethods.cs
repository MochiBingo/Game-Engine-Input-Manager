using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEditor;

public class objectMethods : MonoBehaviour
{
    public GameObject player;
    public GameObject interacter;
    public Renderer qObject;

    public void Awake()
    {
        InputActions.jumpEventStarted += jumpUp;
        InputActions.jumpEventCanceled += jumpDown;
        InputActions.interactEventStarted += moveBoxOut;
        InputActions.interactEventCanceled += moveBoxIn;
        InputActions.qEventStarted += Qstarted;
        InputActions.qEventPerformed += Qperformed;
        InputActions.qEventCanceled += Qcanceled;
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
