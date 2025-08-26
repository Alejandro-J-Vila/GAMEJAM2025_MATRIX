using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneByIndex : MonoBehaviour
{
    public void LoadScene(int sceneIndex)
    {
        // Unpause the game
        Time.timeScale = 1;
        // Load a scene based on build index
        SceneManager.LoadScene(sceneIndex);
    }
}
