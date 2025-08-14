using UnityEngine;

public class CreditsRoll : MonoBehaviour
{
    public float scrollSpeed = 120f; // Rolling credits speed
    private RectTransform creditsPanel; // Credits panel that is going to scroll
    void Start()
    {
        // Get the reference to the scrolling panel
        creditsPanel = GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        // Move the panel up
        creditsPanel.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
        // When the panel reach the final position, reset it to the initial position
        if (creditsPanel.anchoredPosition.y >= 2859)
        {
            creditsPanel.anchoredPosition -= new Vector2(0, 3916);
        }
    }
}
