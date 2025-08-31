using UnityEngine;

public class AudioToggle : MonoBehaviour
{
    public void SoundOn()
    {
        // Turn the sound on
        SoundManager.sm.SoundOn();
    }

    public void SoundOff()
    {
        // Turn the sound off
        SoundManager.sm.SoundOff();
    }

    public void MusicOn()
    {
        // Turn the music on
        SoundManager.sm.MusicOn();
    }

    public void MusicOff()
    {
        // Turn the music off
        SoundManager.sm.MusicOff();
    }
}
