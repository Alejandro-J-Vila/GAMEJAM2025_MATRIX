using UnityEngine;

public class AudioToggle : MonoBehaviour
{
    public void SoundToggle()
    {
        // Toggle sound on/off
        SoundManager.sm.SoundOn();
    }

    public void MusicToggle()
    {
        // Togle music on/off
        SoundManager.sm.MusicOn();
    }
}
