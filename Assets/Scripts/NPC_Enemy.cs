using UnityEngine;
using UnityEngine.UI;

public class NPCEnemy : MonoBehaviour
{
    public GameObject uiWindow;
    public AudioSource audioSource;
    public Text textField;
    public string text = "I deal 10 physical damage    ( •̀ᴗ•́ )و ̑̑ ";

    public void GetHit()
    {
        uiWindow.SetActive(true);
        textField.text = text;
        audioSource.Play();
        FindObjectOfType<Player>().ReceiveDamage();
    }
}