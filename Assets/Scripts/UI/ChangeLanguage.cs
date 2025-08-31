using TMPro;
using UnityEngine;

public class ChangeLanguage : MonoBehaviour
{
    public TMP_Text settingsTitle; // Reference to the settings title text
    public TMP_Text soundTitle; // Reference to the sound title text
    public TMP_Text musicTitle; // Reference to the music title text
    public TMP_Text languageTitle; // Reference to the language title text
    public TMP_Text languageButtonES; // Reference to the spanish button text
    public TMP_Text languageButtonEN; // Reference to the english button text
    public TMP_Text backButton; // Reference to the back button text

    public void SetLanguageES()
    {
        // Set the language of the game to spanish
        TextManager.tm.SetLanguageSpanish();
        // Update all the text elements in the settings screen to the new language
        UpdateSettingsScreen();
    }

    public void SetLanguageEN()
    {
        // Set the language of the game to english
        TextManager.tm.SetLanguageEnglish();
        // Update all the text elements in the settings screen to the new language
        UpdateSettingsScreen();
    }

    public void UpdateSettingsScreen()
    {
        // Update all the text elements in the settings screen to the new language selected
        settingsTitle.GetComponent<TextUpdate>().UpdateText();
        soundTitle.GetComponent<TextUpdate>().UpdateText();
        musicTitle.GetComponent<TextUpdate>().UpdateText();
        languageTitle.GetComponent<TextUpdate>().UpdateText();
        languageButtonES.GetComponent<TextUpdate>().UpdateText();
        languageButtonEN.GetComponent<TextUpdate>().UpdateText();
        backButton.GetComponent<TextUpdate>().UpdateText();
    }
}
