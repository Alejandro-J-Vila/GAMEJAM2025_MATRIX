using TMPro;
using UnityEngine;

public class TextGlitch : MonoBehaviour
{
    public void ChangeText(string text)
    {
        TMP_Text txt = GetComponent<TMP_Text>();
        if (txt == null)
        {
            txt = GetComponentInChildren<TMP_Text>();
        }
        txt.SetText(text);
    }
}
