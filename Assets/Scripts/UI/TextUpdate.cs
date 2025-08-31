using TMPro;
using UnityEngine;

public class TextUpdate : MonoBehaviour
{
    private TMP_Text text; // Reference to the text component in the game object
    public string textId; // Text id to access the text map
    public string place; // Text place to select the correct text map
    void Start()
    {
        // Get the reference to the text component
        text = this.GetComponent<TMP_Text>();
        // Set the default text of the game object
        text.SetText(TextManager.tm.GetText(place, textId));
    }

    public void UpdateText()
    {
        // Get the reference to the text component
        text = this.GetComponent<TMP_Text>();
        // Update the text of the game object
        text.SetText(TextManager.tm.GetText(place, textId));
    }
}
