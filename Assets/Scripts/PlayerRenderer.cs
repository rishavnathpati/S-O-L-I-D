using System.Collections;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    public SpriteRenderer playerRenderer;

    public bool IsSpriteFlipped => playerRenderer.flipX;

    internal void RenderPlayer(Vector2 movementVector)
    {
        if (Mathf.Abs(movementVector.x) > 0.1f)
        {
            playerRenderer.flipX = Vector3.Dot(transform.right, movementVector) < 0;
        }
    }

    public void FlashRed()
    {
        StopAllCoroutines();
        StartCoroutine(FlashRedCoroutine());
    }

    private IEnumerator FlashRedCoroutine()
    {
        playerRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        playerRenderer.color = Color.white;
    }
}
