using UnityEngine;

public class AudioToggle : MonoBehaviour
{
    public void SoundToggle()
    {
        SoundManager.sm.SoundOn();
    }

    public void MusicToggle()
    {
        SoundManager.sm.MusicOn();
    }
}
