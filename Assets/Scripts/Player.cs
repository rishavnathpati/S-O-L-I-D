using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerAIInteractions playerAIInteractions;
    public PlayerMovement playerMovement;
    public GameObject uiWindow;
    public PlayerRenderer playerRenderer;
    public PlayerInput playerInput;
    public PlayerAnimations playerAnimations;
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerRenderer = GetComponent<PlayerRenderer>();
        playerAIInteractions = GetComponent<PlayerAIInteractions>(); 
        playerInput = GetComponent<PlayerInput>();
        playerAnimations = GetComponent<PlayerAnimations>();
        
        playerInput.OnInteractEvent += () => playerAIInteractions.Interact(playerRenderer.IsSpriteFlipped);
    }

    private void FixedUpdate()
    {
        playerMovement.MovePlayer(playerInput.MovementInputVector);
        playerRenderer.RenderPlayer(playerInput.MovementInputVector);        
        playerAnimations.SetupAnimations(playerInput.MovementInputVector);    

        if (playerInput.MovementInputVector.magnitude > 0)
            uiWindow.SetActive(false);
    }

    public void ReceiveDamage()
    {
        playerRenderer.FlashRed();
    }
}