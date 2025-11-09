using UnityEngine;

public class FuelCollectable : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float destroyY = -6f;
    public float fuelAmount = 30f; // Quanto combustível ele reabastece

    void Update()
    {
        // Move para baixo (assim como o EnemyCar)
        if (TrafficSpawner.isGameOver == false)
        {
            transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
        }

        // Destroi se sair da tela
        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }
    }

    // Chamado quando um objeto entra em um Collider marcado como Is Trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que colidiu é o jogador
        // (Assumindo que seu PlayerCar tem a Tag "Player")
        if (other.CompareTag("Player"))
        {
            // Pega a referência do script do jogador
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                // Adiciona o combustível ao jogador
                player.AddFuel(fuelAmount);

                // Destroi o coletável
                Destroy(gameObject);
            }
        }
    }
}