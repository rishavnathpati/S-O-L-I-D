using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource audioSource;
    public void PlayStepSound()
    {
        audioSource.Play();
    }
}
