using UnityEngine;

public class FuelCollectable : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float destroyY = -6f;
    public float fuelAmount = 30f;

    void Update()
    {
        if (TrafficSpawner.isGameOver == false)
        {
            transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
        }

        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                player.AddFuel(fuelAmount);
                Destroy(gameObject);
            }
        }
    }
}