using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NPC_Enemy : MonoBehaviour
{
    public UnityEvent<string> OnSpeak;
    public AudioSource audioSource;
    public string text = "I deal 10 physical damage    ( •̀ᴗ•́ )و ̑̑ ";

    public void GetHit()
    {
        OnSpeak?.Invoke(text);
        audioSource.Play();
        FindObjectOfType<Player>().ReceiveDamaged();
    }

}
