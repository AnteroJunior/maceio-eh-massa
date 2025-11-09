using UnityEngine;

public class TrafficSpawner : MonoBehaviour
{
    private UIManager uiManager;
    public GameObject enemyPrefab;
    public GameObject fuelPrefab;
    public float fuelSpawnChance = 0.2f;
    public float spawnRate = 2f;
    private float nextSpawn = 0f;
    public float minX = -0.5f;
    public float maxX = 0.5f;
    public float spawnY = 6f;
    public static bool isGameOver = false;
    public float score = 0f;
    public float scorePerSecond = 10f;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        isGameOver = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (isGameOver)
        {
            return;
        }

        score += scorePerSecond * Time.deltaTime;

        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, spawnY, transform.position.z);

            // Lógica para decidir se é carro inimigo ou combustível
            GameObject prefabToSpawn;

            // Random.value retorna um float entre 0.0 e 1.0
            if (Random.value < fuelSpawnChance)
            {
                // Spawnar Combustível (20% das vezes)
                prefabToSpawn = fuelPrefab;
            }
            else
            {
                // Spawnar Inimigo (80% das vezes)
                prefabToSpawn = enemyPrefab;
            }

            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    public void EndGame()
    {
        if (isGameOver == false)
        {
            isGameOver = true;
            Debug.Log("Fim de Jogo! Você bateu.");

            if (uiManager != null)
            {
                uiManager.ShowGameOver();
            }

            Time.timeScale = 0f;
        }
    }
}