using UnityEngine;

public class Chase : MonoBehaviour
{
    public float speed = 3; // Object movement speed
    private GameObject target; // Object's target to chase
    private Rigidbody2D rb; // Rigidbody2D component of the object

    void Start()
    {
        // Get target reference
        target = GameObject.FindGameObjectWithTag("Player");
        // Initialize the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        // Prevent the object from rotating continuosly
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // Calculate the movement direction towards the target
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
    }
}
