using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField]
    private GameObject ui_window;
    [SerializeField]
    private Text textField;

    public void ToggleUI(bool val)
    {
        ui_window.SetActive(val);
    }

    public void ShowText(string text)
    {
        ToggleUI(true);
        textField.text = text;
    }
}
