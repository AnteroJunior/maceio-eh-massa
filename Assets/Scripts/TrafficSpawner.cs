using UnityEngine;

public class TrafficSpawner : MonoBehaviour
{
    // O prefab (modelo) do carro inimigo
    public GameObject enemyPrefab; 
    
    // Intervalo de tempo entre cada carro gerado
    public float spawnRate = 2f; 
    
    // O tempo do próximo spawn (será atualizado no código)
    private float nextSpawn = 0f; 
    
    // Limites de X onde os carros podem aparecer
    public float minX = -0.5f; 
    public float maxX = 0.5f; 
    
    // Altura onde os carros devem aparecer (acima da tela)
    public float spawnY = 6f; 

    void Update()
    {
        // Verifica se é hora de gerar um novo carro
        if (Time.time > nextSpawn)
        {
            // 1. Atualiza o tempo do próximo spawn
            nextSpawn = Time.time + spawnRate;

            // 2. Calcula a posição X aleatória
            // Random.Range inclui o minX, mas exclui o maxX (por padrão em floats)
            float randomX = Random.Range(minX, maxX); 
            
            // 3. Define a posição completa (X aleatório, Y fixo, Z fixo)
            Vector3 spawnPosition = new Vector3(randomX, spawnY, transform.position.z);
            
            // 4. Cria uma instância do prefab na posição e rotação (Quaternion.identity = sem rotação)
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}