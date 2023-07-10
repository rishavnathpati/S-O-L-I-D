using UnityEngine;
using UnityEngine.Events;

public class NPCEnemy : MonoBehaviour
{
    public AudioSource audioSource;
    public string text = "I deal 10 physical damage    ( •̀ᴗ•́ )و ̑̑ ";
    public UnityEvent<string> onSpeak;

    public void GetHit()
    {
        onSpeak?.Invoke(text);
        audioSource.Play();
        FindObjectOfType<Player>().ReceiveDamage();
    }
}