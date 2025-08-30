using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sm; // Static reference of the sound manager
    public AudioClip[] musicList; // List of music clips of the game to play in the different scenes
    public AudioClip[] soundList; // List of sound clips of the game to play in the different situations
    private AudioSource soundsAudioSource; // Reference to the audio source that play sound effects in the scene
    private AudioSource musicAudioSource; // Reference to the audio source that play music in the scene
    private static bool soundOn = true; // Flag for sound on/off
    private static bool musicOn = true; // Flag for music on/off
    private static bool inMenus = false; // Flag for not starting over the music when navigating menus
    private Dictionary<string, int> musicMap; // Dictionary that map music names to list index numbers
    private Dictionary<string, int> soundMap; // Dictionary that map sound names to list index numbers
    private Button soundOnBut;
    private Button soundOffBut;
    private Button musicOnBut;
    private Button musicOffBut;
    public Sprite onEnabled;
    public Sprite onDisabled;
    public Sprite offEnabled;
    public Sprite offDisabled;

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
            { "Victory", 2 },
            { "Game_Over", 3 },
            { "Story", 4 }
        };
        // Create the sound map
        soundMap = new Dictionary<string, int>
        {
            // Add all sound names maped to the corresponding index in the list
            { "Player_Attack_S", 0 },
            { "Player_Attack_L", 1 },
            { "Player_Attack_E", 2 },
            { "LifePU_PickUp", 3 },
            { "Enemy_Attack", 4 },
            { "KamikazeE_Death", 5 },
            { "StaticE_Death", 6 },
            { "StaticE_Spawn", 7 }
        };
        // Get the audio sources for sounds and music.
        soundsAudioSource = GameObject.FindWithTag("SoundPlayer").GetComponent<AudioSource>();
        musicAudioSource = GameObject.FindWithTag("MusicPlayer").GetComponent<AudioSource>();
        // Set this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        // Subscribe to the scene loaded event to configure music when different scenes are loaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // If the scene loaded is the main menu
        if (scene.name == "MainMenuScene")
        {
            // If we are not in menus
            if (!inMenus)
            {
                // Set the in menus flag to true because we enter the menus coming from the game or just started the game
                inMenus = true;
                // Play the main menu music
                PlaySceneMusic("Main_Menu");
            }
        }
        // If the scene loaded is the settings
        if (scene.name == "SettingsScene")
        {
            // Set the sound and music toggles
            SetToggles();
        }
        // If the scene loaded is the level
        if (scene.name == "LevelOneScene")
        {
            // Play the level music
            PlaySceneMusic("Level_One");
            // Set the sound and music toggles from the pause panel
            SetToggles();
        }
        // If the scene loaded is the victory scene
        if (scene.name == "VictoryScene")
        {
            // Play the victory screen music
            PlaySceneMusic("Victory");
        }
        // If the scene loaded is the defeat scene
        if (scene.name == "DefeatScene")
        {
            // Play the defeat screen music
            PlaySceneMusic("Game_Over");
        }
        // If the scene loaded is the story scene
        if (scene.name == "StoryScene")
        {
            // Set the in menus flag to false because we are leaving the menus, and this is the only scene that leaves the menus
            inMenus = false;
            // Play the story music
            PlaySceneMusic("Story");
        }
    }

    private void PlaySceneMusic(string musicKey)
    {
        // Stop the current music clip
        musicAudioSource.Stop();
        // Select the music clip
        musicAudioSource.clip = musicList[musicMap[musicKey]];
        // Activate clip loop
        musicAudioSource.loop = true;
        // Play the music clip
        musicAudioSource.Play();
    }

    public void PlayMusic(string musicName)
    {
        // Stop the current clip
        musicAudioSource.Stop();
        // Deactivate clip loop
        musicAudioSource.loop = false;
        // Play a music clip selected with index from a list of clips stored in the manager
        musicAudioSource.PlayOneShot(musicList[musicMap[musicName]]);
    }

    public void PlaySound(string soundName)
    {
        // Play sound clip selected using the index obtained from the sound map
        soundsAudioSource.PlayOneShot(soundList[soundMap[soundName]]);
    }

    private void SetToggles()
    {
        // Get the reference to the toggles
        soundOnBut = GameObject.FindGameObjectWithTag("SoundON").GetComponent<Button>();
        soundOffBut = GameObject.FindGameObjectWithTag("SoundOFF").GetComponent<Button>();
        musicOnBut = GameObject.FindGameObjectWithTag("MusicON").GetComponent<Button>();
        musicOffBut = GameObject.FindGameObjectWithTag("MusicOFF").GetComponent<Button>();
        // If sound is on or off
        if (soundOn)
        {
            soundOnBut.image.sprite = onEnabled;
            soundOffBut.image.sprite = offDisabled;
        }
        else
        {
            soundOnBut.image.sprite = onDisabled;
            soundOffBut.image.sprite = offEnabled;
        }
        // If music is on or off
        if (musicOn)
        {
            musicOnBut.image.sprite = onEnabled;
            musicOffBut.image.sprite = offDisabled;
        }
        else
        {
            musicOnBut.image.sprite = onDisabled;
            musicOffBut.image.sprite = offEnabled;
        }
    }

    public void SoundOn()
    {
        // Turn on sound flag
        soundOn = true;
        // Unmute the sound audio source
        soundsAudioSource.mute = false;
        soundOnBut.image.sprite = onEnabled;
        soundOffBut.image.sprite = offDisabled;
    }

    public void SoundOff()
    {
        // Turn off sound flag
        soundOn = false;
        // Mute the sound audio source
        soundsAudioSource.mute = true;
        soundOnBut.image.sprite = onDisabled;
        soundOffBut.image.sprite = offEnabled;
    }

    public void MusicOn()
    {
        // Turn music flag on
        musicOn = true;
        // Unmute the music audio source
        musicAudioSource.mute = false;
        musicOnBut.image.sprite = onEnabled;
        musicOffBut.image.sprite = offDisabled;
    }

    public void MusicOff()
    {
        // Turn music flag off
        musicOn = false;
        // Mute the music audio source
        musicAudioSource.mute = true;
        musicOnBut.image.sprite = onDisabled;
        musicOffBut.image.sprite = offEnabled;
    }

    public bool SoundState()
    {
        return soundOn;
    }

    public bool MusicState()
    {
        return musicOn;
    }
}
