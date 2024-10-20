using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject uiWindow;

    [SerializeField] private Text textField;
    public void ShowText(string text)
    {
        ToggleUI(true);
        textField.text = text;
    }

    public void ToggleUI(bool val) => uiWindow.SetActive(val);

}
