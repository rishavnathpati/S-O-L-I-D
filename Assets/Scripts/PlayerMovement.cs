using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    private Rigidbody2D _rb2d;

    private void Awake() => _rb2d = GetComponent<Rigidbody2D>();

    public void MovePlayer(Vector2 movementVector) => _rb2d.velocity = movementVector * movementSpeed;
}
