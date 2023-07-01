using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    public float movementSpeed;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    
    public void MovePlayer(Vector2 movementVector)
    {
        _rb2d.velocity = movementVector * movementSpeed;
    }

}
