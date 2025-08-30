using UnityEngine;

public class AudioToggle : MonoBehaviour
{
    public void SoundOn()
    {
        SoundManager.sm.SoundOn();
    }

    public void SoundOff()
    {
        SoundManager.sm.SoundOff();
    }

    public void MusicOn()
    {
        SoundManager.sm.MusicOn();
    }

    public void MusicOff()
    {
        SoundManager.sm.MusicOff();
    }
}
