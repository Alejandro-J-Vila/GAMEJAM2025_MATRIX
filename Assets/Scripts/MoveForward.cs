using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 10; // Object movement speed
    
    void Start()
    {
        
    }

    void Update()
    {
        // Moves the object forward
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
}
