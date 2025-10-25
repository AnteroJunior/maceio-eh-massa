using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // A velocidade base de rolagem do jogo (deve ser a mesma do RoadScroller)
    public float scrollSpeed = 5f; 
    
    // Ponto onde o carro deve ser destruído para não sobrecarregar o jogo
    public float destroyY = -6f; 

    void Update()
    {
        // Movimenta o carro para baixo, criando a ilusão de que o jogador avança
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        // Se o carro sair da tela por baixo, destrua-o
        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }
    }
}