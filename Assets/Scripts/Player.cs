using UnityEngine;

/// <summary>
/// Represents the main player character and manages its components and behaviors.
/// </summary>
public class Player : MonoBehaviour
{
    private const float MOVEMENT_THRESHOLD = 0.01f;

    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerRenderer _playerRenderer;
    [SerializeField] private PlayerAIInteractions _playerAiInteractions;
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private UiController _uiController;

    private IMovementInput _movementInput;

    private void Start()
    {
        _playerAnimations = GetComponent<PlayerAnimations>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerRenderer = GetComponent<PlayerRenderer>();
        _playerAiInteractions = GetComponent<PlayerAIInteractions>();
        _movementInput = GetComponent<IMovementInput>();
        _movementInput.OnInteractEvent += () =>
        {
            if (_playerAiInteractions != null)
            {
                _playerAiInteractions.Interact(_playerRenderer.IsSpriteFlipped);
            }
        };
    }

    private void FixedUpdate()
    {
        Vector2 movementInput = _movementInput.MovementInputVector;

        _playerMovement.MovePlayer(movementInput);
        _playerRenderer.RenderPlayer(movementInput);
        _playerAnimations.SetupAnimations(movementInput);

        if (movementInput.magnitude > MOVEMENT_THRESHOLD)
        {
            _uiController.ToggleUI(false);
        }
    }

    /// <summary>
    /// Handles the player receiving damage.
    /// </summary>
    public void ReceiveDamage()
    {
        _playerRenderer.FlashRed();
    }
}
