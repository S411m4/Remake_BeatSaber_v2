using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class GameInput : MonoBehaviour
{
    [SerializeField] InputActionReference pause;

    public event EventHandler onPause;
    public static GameInput Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        pause.action.performed += Pause_performed;
    }

    private void Pause_performed(InputAction.CallbackContext obj)
    {
        if (pause.action.IsPressed())
        {
            onPause?.Invoke(this, EventArgs.Empty);
        }
    }
}
