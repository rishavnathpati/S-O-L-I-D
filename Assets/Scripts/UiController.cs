using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField]
    private GameObject _uiWindow;
    [SerializeField]
    private Text _textField;

    public void ToggleUI(bool val)
    {
        _uiWindow.SetActive(val);
    }

    public void ShowText(string text)
    {
        ToggleUI(true);
        _textField.text = text;
    }
}
