using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sm; // Static reference of the sound manager
    public AudioClip[] musicList; // List of music clips of the game to play in the different scenes
    public AudioClip[] soundList; // List of sound clips of the game to play in the different situations
    private Dictionary<string, int> musicMap; // Dictionary that map music names to list index numbers
    private Dictionary<string, int> soundMap; // Dictionary that map sound names to list index numbers
    private AudioSource soundsAudioSource; // Reference to the audio source that play sound effects in the scene
    private AudioSource musicAudioSource; // Reference to the audio source that play music in the scene

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
}
