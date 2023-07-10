using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MovementInputVector { get; private set; }

    private void Update()
    {
        GetInteractInput();
        GetMovementInput();
    }

    public event Action OnInteractEvent;

    private void GetMovementInput()
    {
        MovementInputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        MovementInputVector.Normalize();
    }

    private void GetInteractInput()
    {
        if (Input.GetAxisRaw("Fire1") > 0) OnInteractEvent?.Invoke();
    }
}