using UnityEngine;

public class RoadScroller : MonoBehaviour
{
    public float scrollSpeed = 20f;
    public Transform[] roadSections;
    public float roadHeight = 2f;

    private float loopPointY;

    void Update()
    {
        foreach (Transform road in roadSections)
        {
            road.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

            if (road.position.y < -roadHeight) 
            {
                float offset = roadHeight * 2f; 
                road.position = new Vector3(road.position.x, road.position.y + offset, road.position.z);
            }
        }
    }
}