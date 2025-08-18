using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sm; // Static reference of the sound manager
    public AudioClip[] musicList; // List of music clips of the game to play in the different scenes
    public AudioClip[] soundList; // List of sound clips of the game to play in the different situations
    private AudioSource soundsAudioSource; // Reference to the audio source that play sound effects in the scene
    private AudioSource musicAudioSource; // Reference to the audio source that play music in the scene
    private static bool soundOn = true; // Flag for sound on/off
    private static bool musicOn = true; // Flag for music on/off
    private Dictionary<string, int> musicMap; // Dictionary that map music names to list index numbers
    private Dictionary<string, int> soundMap; // Dictionary that map sound names to list index numbers
    private TMP_Text soundToggle; // Reference to the sound toggle
    private TMP_Text musicToggle; // Reference to the music toggle

    void Awake()
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
        musicMap = new Dictionary<string, int>
        {
            // Add all music names maped to the corresponding index in the list
            { "Main_Menu", 0 },
            { "Level_One", 1 },
            { "Game_Over", 2 }
        };
        // Create the sound map
        soundMap = new Dictionary<string, int>
        {
            // Add all sound names maped to the corresponding index in the list
            { "Kamikaze_Hit", 0 },
            { "Enemy_Death", 1 },
            { "LifePowerUp_PickUp", 2 }
        };
        soundsAudioSource = GameObject.FindWithTag("SoundPlayer").GetComponent<AudioSource>();
        musicAudioSource = GameObject.FindWithTag("MusicPlayer").GetComponent<AudioSource>();
        // Set this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        // Subscribe to the scene loaded event to configure music when different scenes are loaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        // If the current scene is the settings scene or the game scene (where the toggles exist)
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
        {

        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenuScene")
        {
            if (musicOn)
            {
                musicAudioSource.Stop();
                musicAudioSource.clip = musicList[musicMap["Main_Menu"]];
                musicAudioSource.loop = true;
                musicAudioSource.Play();
            }
        }
        if (scene.name == "SettingsScene")
        {
            SetToggles();
        }
        if (scene.name == "LevelOneScene")
        {
            if (musicOn)
            {
                musicAudioSource.Stop();
                musicAudioSource.clip = musicList[musicMap["Level_One"]];
                musicAudioSource.loop = true;
                musicAudioSource.Play();
            }
            SetToggles();
        }
    }

    public void PlayMusic(string musicName)
    {
        // If music is on
        if (musicOn)
        {
            musicAudioSource.Stop();
            musicAudioSource.loop = false;
            // Play a music clip selected with index from a list of clips stored in the manager
            musicAudioSource.PlayOneShot(musicList[musicMap[musicName]]);
        }
    }

    public void PlaySound(string soundName)
    {
        // If sound is on
        if (soundOn)
        {
            // Play sound clip selected using the index obtained from the sound map
            soundsAudioSource.PlayOneShot(soundList[soundMap[soundName]]);
        }
    }

    private void SetToggles()
    {
        // Get the reference to the toggles and save the text component for further modification when interacted
        soundToggle = GameObject.FindGameObjectWithTag("SoundToggle").GetComponentInChildren<TMP_Text>();
        musicToggle = GameObject.FindGameObjectWithTag("MusicToggle").GetComponentInChildren<TMP_Text>();
        // If sound is on or off
        if (soundOn)
        {
            // Set the toggle text
            soundToggle.SetText("SOUND ON");
        }
        else
        {
            // Set the toggle text
            soundToggle.SetText("SOUND OFF");
        }
        // If music is on or off
        if (musicOn)
        {
            // Set the toggle text
            musicToggle.SetText("MUSIC ON");
        }
        else
        {
            // Set the toggle text
            musicToggle.SetText("MUSIC OFF");
        }
    }

    public void SoundOn()
    {
        // If sound is on
        if (soundOn)
        {
            // Turn it off
            soundOn = false;
            // Update toggle text
            soundToggle.SetText("SOUND OFF");
            // Mute the sound audio source
            soundsAudioSource.mute = true;
        }
        else
        {
            // If sound is off, turn it on
            soundOn = true;
            // Update toggle text
            soundToggle.SetText("SOUND ON");
            // Unmute the sound audio source
            soundsAudioSource.mute = false;
        }
    }

    public void MusicOn()
    {
        // If music is on
        if (musicOn)
        {
            // Turn it off
            musicOn = false;
            // Update toggle text
            musicToggle.SetText("MUSIC OFF");
            // Mute the music audio source
            musicAudioSource.mute = true;
        }
        else
        {
            // If music is off, turn it on
            musicOn = true;
            // Update toggle text
            musicToggle.SetText("MUSIC ON");
            // Unmute the music audio source
            musicAudioSource.mute = false;
        }
    }
}
