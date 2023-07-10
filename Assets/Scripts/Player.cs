using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerAIInteractions playerAIInteractions;
    public PlayerMovement playerMovement;
    public PlayerRenderer playerRenderer;
    public PlayerInput playerInput;
    public PlayerAnimations playerAnimations;
    public UiController uiController;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerRenderer = GetComponent<PlayerRenderer>();
        playerAIInteractions = GetComponent<PlayerAIInteractions>();
        playerInput = GetComponent<PlayerInput>();
        playerAnimations = GetComponent<PlayerAnimations>();
        uiController = GetComponent<UiController>();

        playerInput.OnInteractEvent += () => playerAIInteractions.Interact(playerRenderer.IsSpriteFlipped);
    }

    private void FixedUpdate()
    {
        var playerInputMovementInputVector = playerInput.MovementInputVector;
        playerMovement.MovePlayer(playerInputMovementInputVector);
        playerRenderer.RenderPlayer(playerInputMovementInputVector);
        playerAnimations.SetupAnimations(playerInputMovementInputVector);

        if (playerInputMovementInputVector.magnitude > 0)
            uiController.SetInteractionUiActive(false);
    }

    public void ReceiveDamage()
    {
        playerRenderer.FlashRed();
    }
}