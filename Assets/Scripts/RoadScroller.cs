using UnityEngine;

public class RoadScroller : MonoBehaviour
{
    public float scrollSpeed = 20f;
    public Transform[] roadSections;
    public float roadHeight = 2f;

    private float loopPointY;

    void Start()
    {
        loopPointY = -roadHeight;
    }

    void Update()
    {
        foreach (Transform road in roadSections)
        {
            road.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

            if (road.position.y < -roadHeight)
            {
                float newYPosition = road.position.y + (roadHeight * 2f);
                road.position = new Vector3(road.position.x, newYPosition, road.position.z);
            }
        }
    }
}