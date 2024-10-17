using System;
using UnityEngine;

public interface IMovementInput
{
    Vector2 MovementInputVector { get; }
    event Action OnInteractEvent;
}
