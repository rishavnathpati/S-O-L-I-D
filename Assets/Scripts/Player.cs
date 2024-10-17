using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerRenderer playerRenderer;
    public PlayerAIInteractions playerAiInteractions;
    public PlayerAnimations playerAnimations;
    public UiController uiController;
    public IMovementInput movementInput;

    private void Start()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
        playerMovement = GetComponent<PlayerMovement>();
        playerRenderer = GetComponent<PlayerRenderer>();
        playerAiInteractions = GetComponent<PlayerAIInteractions>();
        movementInput = GetComponent<IMovementInput>();
        movementInput.OnInteractEvent += () => playerAiInteractions.Interact(playerRenderer.IsSpriteFlipped);
    }

    private void FixedUpdate()
    {
        playerMovement.MovePlayer(movementInput.MovementInputVector);
        playerRenderer.RenderPlayer(movementInput.MovementInputVector);
        playerAnimations.SetupAnimations(movementInput.MovementInputVector);

        if (movementInput.MovementInputVector.magnitude > 0) uiController.ToggleUI(false);
    }

    public void ReceiveDamage()
    {
        playerRenderer.FlashRed();
    }
}
