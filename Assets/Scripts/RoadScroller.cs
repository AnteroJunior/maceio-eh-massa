using UnityEngine;

public class RoadScroller : MonoBehaviour
{
    public float scrollSpeed = 5f; // Esta é a "velocidade" do jogo!
    public Transform[] roadSections; // Vamos arrastar nossas estradas aqui
    public float roadHeight; // A altura de UMA seção da estrada

    private float loopPointY;

    void Start()
    {
        // O ponto onde a estrada deve "teleportar" de volta para cima
        // Se a estrada A está em 0 e tem 10 de altura, o loopPoint é -10
        loopPointY = -roadHeight; 
    }

    void Update()
    {
        // Move CADA seção da estrada para baixo
        foreach (Transform road in roadSections)
        {
            // Move a estrada para baixo baseado no tempo e velocidade
            road.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

            // Verifica se a estrada saiu da tela (pelo ponto de loop)
            if (road.position.y <= loopPointY)
            {
                // Se saiu, teletransporta ela de volta para cima
                // Ela vai para a altura das duas estradas somadas, menos um tiquinho
                float offset = (roadHeight * roadSections.Length) - 0.05f; // O 0.05f evita "gaps"
                road.position = new Vector3(road.position.x, road.position.y + offset, road.position.z);
            }
        }
    }
}