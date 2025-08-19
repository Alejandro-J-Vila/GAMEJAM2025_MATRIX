using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public string clickSoundID; // Click sound id
    public string hoverSoundID; // Hover sound id

    public void PlayClickSound()
    {
        SoundManager.sm.PlaySound(clickSoundID);
    }

    public void PlayHoverSound()
    {
        SoundManager.sm.PlaySound(hoverSoundID);
    }
}
