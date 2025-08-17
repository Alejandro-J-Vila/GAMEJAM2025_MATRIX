using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sm; // Static reference of the sound manager
    public AudioClip[] musicList; // List of music clips of the game to play in the different scenes
    public AudioClip[] soundList; // List of sound clips of the game to play in the different situations
    private Dictionary<string, int> musicMap; // Dictionary that map music names to list index numbers
    private Dictionary<string, int> soundMap; // Dictionary that map sound names to list index numbers
    private AudioSource soundsAudioSource; // Reference to the audio source that play sound effects in the scene
    private AudioSource musicAudioSource; // Reference to the audio source that play music in the scene
    private TMP_Text soundToggle; // Reference to the sound toggle
    private TMP_Text musicToggle; // Reference to the music toggle
    private bool soundOn = true; // Flag for sound on/off
    private bool musicOn = true; // Flag for music on/off

    void Start()
    {
        if (sm != null && sm != this)
        {
            Destroy(gameObject); // Only one instance of sound manager allowed
        }
        else
        {
            sm = this; // Inicialise the sound manager instance
        }
        // Create the music map
        musicMap = new Dictionary<string, int>();
        // Add all music names maped to the corresponding index in the list
        // TODO

        // Create the sound map
        soundMap = new Dictionary<string, int>();
        // Add all sound names maped to the corresponding index in the list
        soundMap.Add("Kamikaze_Hit", 0);
        soundMap.Add("Enemy_Death", 1);
        soundMap.Add("LifePowerUp_PickUp", 2);
        // Get the reference to the sounds audio source in the scene
        soundsAudioSource = GameObject.FindWithTag("SoundPlayer").GetComponent<AudioSource>();
        // Get the reference to the music audio source in the scene
        musicAudioSource = GameObject.FindWithTag("MusicPlayer").GetComponent<AudioSource>();
        // If the current scene is the settings scene or the game scene (where the toggles exist)
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
        {
            // Get the reference to the toggles and save the text component for further modification when interacted
            soundToggle = GameObject.FindGameObjectWithTag("SoundToggle").GetComponentInChildren<TMP_Text>();
            musicToggle = GameObject.FindGameObjectWithTag("MusicToggle").GetComponentInChildren<TMP_Text>();
        }
    }

    public void PlayMusic(int musicListIndex)
    {
        // Play a music clip selected with index from a list of clips stored in the manager
    }

    public void PlaySound(string soundName)
    {
        // Play sound clip selected using the index obtained from the sound map
        soundsAudioSource.PlayOneShot(soundList[soundMap[soundName]]);
    }

    public void SoundOn()
    {
        // If sound is on
        if (soundOn == true)
        {
            // Turn it off
            soundOn = false;
            // Update toggle text
            soundToggle.SetText("SOUND OFF");
        }
        else
        {
            // If sound is off, turn it on
            soundOn = true;
            // Update toggle text
            soundToggle.SetText("SOUND ON");
        }
    }

    public void MusicOn()
    {
        // If music is on
        if (musicOn == true)
        {
            // Turn it off
            musicOn = false;
            // Update toggle text
            musicToggle.SetText("MUSIC OFF");
        }
        else
        {
            // If music is off, turn it on
            musicOn = true;
            // Update toggle text
            musicToggle.SetText("MUSIC ON");
        }
    }
}
