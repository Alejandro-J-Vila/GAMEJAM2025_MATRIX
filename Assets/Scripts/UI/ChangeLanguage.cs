using TMPro;
using UnityEngine;

public class ChangeLanguage : MonoBehaviour
{
    public TMP_Text settingsTitle;
    public TMP_Text soundTitle;
    public TMP_Text musicTitle;
    public TMP_Text languageTitle;
    public TMP_Text languageButtonES;
    public TMP_Text languageButtonEN;
    public TMP_Text backButton;

    public void SetLanguageES()
    {
        TextManager.tm.SetLanguageSpanish();
        UpdateSettingsScreen();
    }

    public void SetLanguageEN()
    {
        TextManager.tm.SetLanguageEnglish();
        UpdateSettingsScreen();
    }

    public void UpdateSettingsScreen()
    {
        settingsTitle.GetComponent<TextUpdate>().UpdateText();
        soundTitle.GetComponent<TextUpdate>().UpdateText();
        musicTitle.GetComponent<TextUpdate>().UpdateText();
        languageTitle.GetComponent<TextUpdate>().UpdateText();
        languageButtonES.GetComponent<TextUpdate>().UpdateText();
        languageButtonEN.GetComponent<TextUpdate>().UpdateText();
        backButton.GetComponent<TextUpdate>().UpdateText();
    }
}
