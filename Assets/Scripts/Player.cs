using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Animator playerAnimator;
    public SpriteRenderer playerRenderer;

    public Transform raycastPoint;
    
    public PlayerMovement playerMovement;

    public GameObject uiWindow;

    // private Rigidbody2D _rb2d;
    
    private Vector2 _movementVector;
    private static readonly int Walk = Animator.StringToHash("Walk");

   

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        _movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _movementVector.Normalize();
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            Interact();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer(_movementVector);
        if (_movementVector.magnitude > 0)
        {
            uiWindow.SetActive(false);
        }
        else
        {
            playerAnimator.SetBool(Walk, false);
        }
    }

    private void Interact()
    {
        Debug.DrawRay(raycastPoint.position, playerRenderer.flipX ? Vector3.left : Vector3.right, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(raycastPoint.position, playerRenderer.flipX ? Vector3.left : Vector3.right,1);
        if(hit.collider != null)
        {
            if (hit.collider.GetComponent<NPCEnemy>())
            {
                hit.collider.GetComponent<NPCEnemy>().GetHit();
            }
            else if (hit.collider.GetComponent<NPCFriendly>())
            {
                hit.collider.GetComponent<NPCFriendly>().Talk();
            }
        }

    }

    private void MovePlayer(Vector2 movementVector)
    {
        playerAnimator.SetBool(Walk, true);
        //rb2d.MovePosition(rb2d.position + movementVector * movementSpeed * Time.fixedDeltaTime);
        playerMovement.MovePlayer(movementVector);
        if (Mathf.Abs(movementVector.x) > 0.1f)
            playerRenderer.flipX = Vector3.Dot(transform.right, movementVector) < 0;
    }

    public void ReceiveDamage()
    {
        StopAllCoroutines();
        StartCoroutine(FlashRed());
    }

    private IEnumerator FlashRed()
    {
        playerRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        playerRenderer.color = Color.white;
    }
}
