using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private static readonly int Walk = Animator.StringToHash("Walk");
    public Animator playerAnimator;

    public void SetupAnimations(Vector2 movementVector)
    {
        playerAnimator.SetBool(Walk, movementVector.magnitude > 0);
    }
}