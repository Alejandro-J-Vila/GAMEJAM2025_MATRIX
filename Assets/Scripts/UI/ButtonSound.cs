using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public string clickSoundID; // Click sound id
    public void PlayClickSound()
    {
        SoundManager.sm.PlaySound(clickSoundID);
    }
}
