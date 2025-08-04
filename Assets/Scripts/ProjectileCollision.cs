using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // When the projectile collides with an enemy, destroys both
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else
        {
            //TODO
        }
    }
}
