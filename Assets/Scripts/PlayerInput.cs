using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IMovementInput
{
    private void Update()
    {
        GetInteractInput();
        GetMovementInput();
    }

    public Vector2 MovementInputVector { get; private set; }
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
