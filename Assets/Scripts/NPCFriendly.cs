using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class NPCFriendly : MonoBehaviour
{
    [FormerlySerializedAs("ui_window")] public GameObject uiWindow;
    public AudioSource audioSource;
    public Text textField;
    public string text = "Hi there. Look out for that KOBOLD on the other side!";

    public void Talk()
    {
        uiWindow.SetActive(true);
        textField.text = text;
        audioSource.Play();
    }
}