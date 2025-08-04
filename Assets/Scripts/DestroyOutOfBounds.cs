using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float verticalLimit = 5; // Screen vertical limit for the object
    private float horizontalLimit = 10; // Screen horizontal limit for the object
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the object reach the right or left boundaries of the screen, destroy it
        if(transform.position.x < -horizontalLimit)
        {
            Destroy(gameObject);
        }
        if(transform.position.x > horizontalLimit)
        {
            Destroy(gameObject);
        }
        // If the object reach the top or bottom boundaries of the screen, destroy it
        if(transform.position.y > verticalLimit)
        {
            Destroy(gameObject);
        }
        if(transform.position.y < -verticalLimit)
        {
            Destroy(gameObject);
        }
    }
}
