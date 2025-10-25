using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Velocidade de movimento lateral
    public float moveSpeed = 5f; 

    // Referência para o Rigidbody
    private Rigidbody2D rb;

    // Limites da tela (vamos definir depois)
    private float minX = -0.5f;
    private float maxX = 0.5f;

    void Start()
    {
        // Pega o componente Rigidbody que está no mesmo GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Update é ótimo para ler inputs
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
}