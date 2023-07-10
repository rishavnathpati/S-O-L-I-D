using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject uiWindow;
    [SerializeField] private Text textField;

    public void SetInteractionUiActive(bool active)
    {
        uiWindow.SetActive(active);
    }

    public void SetText(string text)
    {
        SetInteractionUiActive(true);
        textField.text = text;
    }
}