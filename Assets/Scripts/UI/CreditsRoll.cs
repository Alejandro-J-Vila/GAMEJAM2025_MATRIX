using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsRoll : MonoBehaviour
{
    public float scrollSpeed = 120f; // Rolling panel speed
    public string panelType; // Type of panel that is going to scroll
    private RectTransform rollingPanel; // Panel that is going to scroll
    void Start()
    {
        // Get the reference to the scrolling panel
        rollingPanel = GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        // Depending on the type of panel, perform specific tasks
        if (panelType == "credits")
        {
            RollCredits();
        }
        if (panelType == "victory")
        {
            RollVictory();
        }
        if (panelType == "defeat")
        {
            RollDefeat();
        }
        if (panelType == "story")
        {
            RollStory();
        }

    }

    private void RollCredits()
    {
        // Move the panel up
        rollingPanel.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
        // When the panel reach the final position, reset it to the initial position
        if (rollingPanel.anchoredPosition.y >= 4080)
        {
            rollingPanel.anchoredPosition -= new Vector2(0, 4941);
        }
    }

    private void RollStory()
    {
        // Move the panel up
        rollingPanel.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
        // When the panel reach the final position, load the game scene
        if (rollingPanel.anchoredPosition.y >= 2580)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void RollVictory()
    {
        // When the panel reach the final position, stop moving
        if (rollingPanel.anchoredPosition.y < 77)
        {
            // Move the panel up
            rollingPanel.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
        }
    }
    
    private void RollDefeat()
    {
        // When the panel reach the final position, stop moving
        if (rollingPanel.anchoredPosition.y < 116)
        {
            // Move the panel up
            rollingPanel.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
        }
    }
}
