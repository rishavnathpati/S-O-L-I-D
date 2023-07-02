using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator playerAnimator;
    private static readonly int Walk = Animator.StringToHash("Walk");

    public void SetupAnimations(Vector2 movementVector)
    {
        playerAnimator.SetBool(Walk, movementVector.magnitude > 0);
    }
}