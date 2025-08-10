using UnityEngine;

public class EnemyKamikaze : MonoBehaviour
{
    public float movementSpeed = 3; // Enemy movement speed
    private GameObject target; // Enemy's target to chase
    private Rigidbody2D rb; // Rigidbody2D component of the enemy

    void Start()
    {
        // Get target reference
        target = GameObject.FindGameObjectWithTag("Player");
        // Get the rigidbody reference
        rb = GetComponent<Rigidbody2D>();
        // Prevent the object from rotating continuosly
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // Calculate the movement direction towards the target
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * movementSpeed);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // When the enemy collides with the player
        if (other.collider.CompareTag("Player"))
        {
            // Damages him
            GameManager.gm.DamagePlayer();
            // Add progress
            GameManager.gm.AddProgress();
            // Die
            Destroy(gameObject);
        }
    }
}
