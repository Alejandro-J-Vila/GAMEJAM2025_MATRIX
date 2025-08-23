using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    // Static reference to the instance of our SceneManager
    public static CustomSceneManager instance;
    private static bool storyPlayed = false;

    private void Awake()
    {
        // Check if instance already exists
        if (instance == null)
        {
            // If not, set instance to this
            instance = this;
        }
        else if (instance != this)
        {
            // If instance already exists and it's not this, then destroy this to enforce the singleton.
            Destroy(gameObject);
        }
        // Set this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        // Subscribe to the scene loaded event to configure settings
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
        // Check if the user is on a non-main scene and presses the quit key
        if (SceneManager.GetActiveScene().buildIndex != 0 && Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 1;
            // Load the main menu scene
            LoadScene(0);
        }
        // Check if the user is on the defeat scene and presses the reset key
        if (SceneManager.GetActiveScene().buildIndex == 7 && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            // Load the game scene
            LoadScene(1);
        }
    }

    // General method to load scenes based on build index
    private void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // If the scene loaded is the level
        if (scene.name == "LevelOneScene")
        {
            // The story was viewed so enable skip for next time
            storyPlayed = true;
        }
    }

    public bool StoryPlayed()
    {
        return storyPlayed;
    }
}
