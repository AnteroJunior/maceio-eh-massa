using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float maxFuel = 100f; // Capacidade máxima
    public float currentFuel;
    public float fuelConsumptionRate = 5f; // Taxa de consumo por segundo (5 unidades/segundo)
    public float collisionFuelPenalty = 20f; // Quanto perde ao bater

    // Velocidade de movimento lateral
    public float moveSpeed = 5f;

    // Referência para o Rigidbody
    private Rigidbody2D rb;

    // Limites da tela (vamos definir depois)
    private float minX = -0.5f;
    private float maxX = 0.5f;

    void Start()
    {
        currentFuel = maxFuel;
        // Pega o componente Rigidbody que está no mesmo GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. Consome combustível constantemente
        // Diminui o combustível usando o tempo desde o último frame (Time.deltaTime)
        if (TrafficSpawner.isGameOver == false) // Só consome se o jogo estiver rodando
        {
            currentFuel -= fuelConsumptionRate * Time.deltaTime;
        }

        // 2. Verifica se o combustível acabou
        if (currentFuel <= 0 && TrafficSpawner.isGameOver == false)
        {
            currentFuel = 0; // Garante que não fica negativo

            // Chamar o método de Game Over
            TrafficSpawner spawner = FindObjectOfType<TrafficSpawner>();
            if (spawner != null)
            {
                spawner.EndGame();
            }
        }
    }

    // FixedUpdate é o local correto para aplicar física (movimento)
    void FixedUpdate()
    {
        // 1. Ler o input do jogador (setas esquerda/direita ou A/D)
        float moveInput = Input.GetAxis("Horizontal"); // Valor entre -1 (esquerda) e 1 (direita)

        // 2. Calcular a nova velocidade
        // Não queremos mudar a velocidade Y (para cima/baixo), apenas a X
        Vector2 newVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        rb.linearVelocity = newVelocity;

        // 3. Limitar o movimento para que o carro não saia da pista
        // Pegamos a posição atual
        Vector2 currentPosition = transform.position;

        // Usamos Mathf.Clamp para "prender" o valor de X entre minX e maxX
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);

        // Aplicamos a posição "presa" de volta ao transform
        transform.position = currentPosition;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            TrafficSpawner spawner = FindObjectOfType<TrafficSpawner>();
            if (spawner != null)
            {
                spawner.EndGame();
            }
            currentFuel -= collisionFuelPenalty;
        }
    }

    public void AddFuel(float amount)
    {
        currentFuel += amount;
        currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel);
    }
}