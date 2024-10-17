using UnityEngine;

public class PlayeSounds : MonoBehaviour
{
    public AudioSource audioSource;
    public void PlayStepSound()
    {
        audioSource.Play();
    }
}
