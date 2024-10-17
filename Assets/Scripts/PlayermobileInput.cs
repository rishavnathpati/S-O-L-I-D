using System;
using UnityEngine;

public class PlayermobileInput : MonoBehaviour, IMovementInput
{
    public Vector2 MovementInputVector { get; private set; }

    public event Action OnInteractEvent;

    public void GetMovementinput(Vector2 direction)
    {
        MovementInputVector = direction;
    }

    public void Interactinput()
    {
        OnInteractEvent?.Invoke();
    }

    public void ResetInput()
    {
        MovementInputVector = Vector2.zero;
    }
}
