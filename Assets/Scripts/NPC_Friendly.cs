using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NPC_Friendly : MonoBehaviour
{
    public UnityEvent<string> OnSpeak;
    public AudioSource audioSource;
    public string text = "Hi there. Look out for that KOBOLD on the other side!";

    public void Talk()
    {
        OnSpeak?.Invoke(text);
        audioSource.Play();
        
    }
}
