using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerRenderer playerRenderer;
    public PlayerAIInteractions playerAiInteractions;
    public PlayerAnimations playerAnimations;
    public UiController uiController;
    public IMovementInput MovementInput;

    private void Start()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
        playerMovement = GetComponent<PlayerMovement>();
        playerRenderer = GetComponent<PlayerRenderer>();
        playerAiInteractions = GetComponent<PlayerAIInteractions>();
        MovementInput = GetComponent<IMovementInput>();
        MovementInput.OnInteractEvent += () => playerAiInteractions.Interact(playerRenderer.IsSpriteFlipped);
    }

    private void FixedUpdate()
    {
        playerMovement.MovePlayer(MovementInput.MovementInputVector);
        playerRenderer.RenderPlayer(MovementInput.MovementInputVector);
        playerAnimations.SetupAnimations(MovementInput.MovementInputVector);

        if (MovementInput.MovementInputVector.magnitude > 0)
        {
            uiController.ToggleUI(false);
        }
    }

    public void ReceiveDamage() => playerRenderer.FlashRed();
}
