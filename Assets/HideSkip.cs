using UnityEngine;

public class HideSkip : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.SetActive(CustomSceneManager.instance.StoryPlayed());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
