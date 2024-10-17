using System.Collections;
using UnityEngine;

/// <summary>
/// Handles the rendering and visual effects for the player character.
/// </summary>
public class PlayerRenderer : MonoBehaviour
{
    private const float MOVEMENT_THRESHOLD = 0.1f;
    private const float FLASH_DURATION = 0.1f;

    [SerializeField] private SpriteRenderer _playerRenderer;

    /// <summary>
    /// Indicates whether the player sprite is currently flipped horizontally.
    /// </summary>
    public bool IsSpriteFlipped => _playerRenderer.flipX;

    /// <summary>
    /// Updates the player's rendering based on the movement vector.
    /// </summary>
    /// <param name="movementVector">The current movement vector of the player.</param>
    public void RenderPlayer(Vector2 movementVector)
    {
        if (Mathf.Abs(movementVector.x) > MOVEMENT_THRESHOLD)
        {
            _playerRenderer.flipX = Vector3.Dot(transform.right, movementVector) < 0;
        }
    }

    /// <summary>
    /// Triggers a red flash effect on the player sprite.
    /// </summary>
    public void FlashRed()
    {
        StopAllCoroutines();
        StartCoroutine(FlashRedCoroutine());
    }

    private IEnumerator FlashRedCoroutine()
    {
        _playerRenderer.color = Color.red;
        yield return new WaitForSeconds(FLASH_DURATION);
        _playerRenderer.color = Color.white;
    }
}
