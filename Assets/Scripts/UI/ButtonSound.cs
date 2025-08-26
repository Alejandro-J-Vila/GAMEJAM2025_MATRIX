using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public string clickSoundID; // Click sound id
    public void PlayClickSound()
    {
        // Play sound when clicking on the button
        SoundManager.sm.PlaySound(clickSoundID);
    }
}
