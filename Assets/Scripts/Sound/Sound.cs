using UnityEngine;

public class Sound : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnToggleSound(bool soundOn){
        if (soundOn)
        {
            Debug.Log("Sound ON");
             AudioListener.volume = 1f;
        }
        else
        {
            Debug.Log("Sound OFF");
             AudioListener.volume = 0f;
        }
    }

        public void OnToggleMusic(bool musicOn){
        if (musicOn)
        {
            Debug.Log("Music ON");
             AudioListener.volume = 1f;
        }
        else
        {
            Debug.Log("Music OFF");
             AudioListener.volume = 0f;
        }
    }
}
