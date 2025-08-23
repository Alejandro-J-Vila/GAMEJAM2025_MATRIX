using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float speed = 5f; // Player movement speed
    public bool canMoveDiagonally = true; // Controls whether the player can move diagonally
    public GameObject projectilePrefab; // Prefab of the player projectiles
    public GameObject projectileSpawn; // Spawn point for player projectiles
    public string shootSoundID; // Id of the shooting sound
    public string damageSoundID; // Id of the damage sound
    public Sprite frontSprite; // Reference to the front sprite
    public Sprite backSprite; // Reference to the back sprite
    private SpriteRenderer sr; // Sprite renderer used to display the sprites
    private Rigidbody2D rb; // Rigidbody2D component of the player
    private Vector2 movement; // Direction of player movement
    private bool isMovingHorizontally = true; // Flag to track if the player is moving horizontally
    private float topLimit = 3f; // Screen top limit for the player
    private float botLimit = -4.5f; // Screen bottom limit for the player
    private float horizontalLimit = 8.4f; // Screen horizontal limit for the player

    void Start()
    {
        // Initialize the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        // Initialize the sprite renderer component
        sr = GetComponentInChildren<SpriteRenderer>();
        // Prevent the player from rotating continuosly
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // Check if the player reached any of the screen boundaries
        CheckBoundaries();
        // Move the player
        ManageMovement();
        // Shoot
        ManageShooting();
        // If the player hits the pause button
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.gm.PauseGame();
        }
        // If the player hits the help button
        if (Input.GetKeyDown(KeyCode.H))
        {
            GameManager.gm.ShowHelp();
        }
    }

    void FixedUpdate()
    {
        // Apply movement to the player in FixedUpdate for physics consistency
        rb.linearVelocity = movement * speed;
    }

    void ManageMovement()
    {
        // Get player input from keyboard or controller
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        // If player is moving up
        if (verticalInput > 0)
        {
            // Change the sprite to the back
            sr.sprite = backSprite;
        }
        else
        {
            // If the player is moving down, change the sprite to the front
            sr.sprite = frontSprite;
        }
        // Check if diagonal movement is allowed
        if (canMoveDiagonally)
        {
            // Set movement direction based on input
            movement = new Vector2(horizontalInput, verticalInput);
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
            // Set movement direction
            if (isMovingHorizontally)
            {
                movement = new Vector2(horizontalInput, 0);
            }
            else
            {
                movement = new Vector2(0, verticalInput);
            }
        }
    }

    void ManageShooting()
    {
        // If the player hits any of the fire buttons (arrow keys), shoot in that direction
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Shoot(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Shoot(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Shoot(Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Shoot(Vector2.left);
        }
    }

    void Shoot(Vector2 direction)
    {
        // Rotate the projectile spawn in the shooting direction
        RotateProjectileSpawn(direction.x, direction.y);
        // Create the projectile to shoot
        GameObject proj = Instantiate(projectilePrefab, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
        // Set the projectile direction
        proj.GetComponent<PlayerProjectile>().SetDirection(direction);
        // Play shooting sound
        SoundManager.sm.PlaySound(shootSoundID);
    }

    void RotateProjectileSpawn(float x, float y)
    {
        // If there is no input, do not rotate the projectile spawn
        if (x == 0 && y == 0)
        {
            return;
        }
        // Calculate the rotation angle based on input direction
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        // Apply the rotation to the projectile spawn
        projectileSpawn.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void CheckBoundaries()
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
        if(transform.position.y > topLimit)
        {
            transform.position = new Vector2(transform.position.x, topLimit);
        }
        if(transform.position.y < botLimit)
        {
            transform.position = new Vector2(transform.position.x, botLimit);
        }
    }
}
