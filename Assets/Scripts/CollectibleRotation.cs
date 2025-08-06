using UnityEngine;

public class CollectibleRotation : MonoBehaviour
{
    public float speed = 90f; // Collectible rotation speed
    void Start()
    {

    }

    void Update()
    {
        // Rotate the collectible arround Y axis
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}