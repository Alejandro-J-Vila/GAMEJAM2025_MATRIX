using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float speed = 5f; // Player movement speed
    public bool canMoveDiagonally = true; // Controls whether the player can move diagonally
    public GameObject projectilePrefab; // Prefab of the player projectiles
    public GameObject projectileSpawn; // Spawn point for player projectiles
    private Rigidbody2D rb; // Rigidbody2D component of the player
    private Vector2 movement; // Direction of player movement
    private bool isMovingHorizontally = true; // Flag to track if the player is moving horizontally
    private float verticalLimit = 4.5f; // Screen vertical limit for the player
    private float horizontalLimit = 8.4f; // Screen horizontal limit for the player

    void Start()
    {
        // Initialize the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        // Prevent the player from rotating continuosly
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // Get player input from keyboard or controller
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        // Check if the player reached any of the screen boundaries
        CheckBoundaries();
        // Check if diagonal movement is allowed
        if (canMoveDiagonally)
        {
            // Set movement direction based on input
            movement = new Vector2(horizontalInput, verticalInput);
            // Rotate the player based on movement direction
            RotatePlayer(horizontalInput, verticalInput);
        }
        else
        {
            // Determine the priority of movement based on input
            if (horizontalInput != 0)
            {
                isMovingHorizontally = true;
            }
            else if (verticalInput != 0)
            {
                isMovingHorizontally = false;
            }

            // Set movement direction and rotate the player
            if (isMovingHorizontally)
            {
                movement = new Vector2(horizontalInput, 0);
                RotatePlayer(horizontalInput, 0);
            }
            else
            {
                movement = new Vector2(0, verticalInput);
                RotatePlayer(0, verticalInput);
            }
        }
        // If the player hits the fire button
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Create a projectile on the spawn point position, with player rotation and fire it
            Instantiate(projectilePrefab, projectileSpawn.transform.position, transform.rotation);
        }
        // If the player hits the help button
        if (Input.GetKeyDown(KeyCode.H))
        {
            // Show/Hide help panel
            GameManager.gm.Help();
        }
    }

    void FixedUpdate()
    {
        // Apply movement to the player in FixedUpdate for physics consistency
        rb.linearVelocity = movement * speed;
    }

    void RotatePlayer(float x, float y)
    {
        // If there is no input, do not rotate the player
        if (x == 0 && y == 0)
        {
            return;
        }
        // Calculate the rotation angle based on input direction
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        // Apply the rotation to the player
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void CheckBoundaries()
    {
        // If the player reach the right or left boundaries of the screen, stop him
        if(transform.position.x < -horizontalLimit)
        {
            transform.position = new Vector2(-horizontalLimit, transform.position.y);
        }
        if(transform.position.x > horizontalLimit)
        {
            transform.position = new Vector2(horizontalLimit, transform.position.y);
        }
        // If the player reach the top or bottom boundaries of the screen, stop him
        if(transform.position.y > verticalLimit)
        {
            transform.position = new Vector2(transform.position.x, verticalLimit);
        }
        if(transform.position.y < -verticalLimit)
        {
            transform.position = new Vector2(transform.position.x, -verticalLimit);
        }
    }
}
