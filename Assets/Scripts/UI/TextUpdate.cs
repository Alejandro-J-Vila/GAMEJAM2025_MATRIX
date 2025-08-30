using TMPro;
using UnityEngine;

public class TextUpdate : MonoBehaviour
{
    private TMP_Text text;
    public string textId;
    public string place;
    void Start()
    {
        text = this.GetComponent<TMP_Text>();
        text.SetText(TextManager.tm.GetText(place, textId));
    }

    public void UpdateText()
    {
        text = this.GetComponent<TMP_Text>();
        text.SetText(TextManager.tm.GetText(place, textId));
    }
}
