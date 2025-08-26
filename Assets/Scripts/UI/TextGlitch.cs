using TMPro;
using UnityEngine;

public class TextGlitch : MonoBehaviour
{
    public void ChangeText(string text)
    {
        // Get the text that we need to modify
        TMP_Text txt = GetComponent<TMP_Text>();
        if (txt == null)
        {
            // If its null, check the children for the text
            txt = GetComponentInChildren<TMP_Text>();
        }
        // Modify the text
        txt.SetText(text);
    }
}
