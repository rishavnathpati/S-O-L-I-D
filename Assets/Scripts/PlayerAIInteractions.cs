using UnityEngine;

public class PlayerAIInteractions : MonoBehaviour
{
    public Transform raycastPoint;

    public void Interact(bool isSpriteFlipped)
    {
        Debug.DrawRay(raycastPoint.position, isSpriteFlipped ? Vector3.left : Vector3.right, Color.red);
        var hit = Physics2D.Raycast(raycastPoint.position, isSpriteFlipped ? Vector3.left : Vector3.right, 1);
        if (hit.collider != null)
        {
            if (hit.collider.GetComponent<NPCEnemy>())
                hit.collider.GetComponent<NPCEnemy>().GetHit();
            else if (hit.collider.GetComponent<NPCFriendly>()) hit.collider.GetComponent<NPCFriendly>().Talk();
        }
    }
}