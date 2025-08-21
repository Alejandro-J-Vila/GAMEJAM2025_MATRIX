using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneByIndex : MonoBehaviour
{
    // General method to load scenes based on build index
    public void LoadScene(int sceneIndex)
    {
        // Unpause the game
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneIndex);
    }
}
