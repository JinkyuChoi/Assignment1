using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2019-10-06 by Jinkyu Choi
public class MapController : MonoBehaviour
{
    //code from Tom Tsiliopoulos
    [Header("Map Controller")]
    public float scrollSpeed;
    public float resetPosition;
    public float resetPoint;

    void Start()
    {

    }

    //code from Tom Tsiliopoulos
    void Update()
    {
        Move();
        CheckBounds();
    }

    //code from Tom Tsiliopoulos
    //This will scroll the Map
    void Move()
    {
        Vector2 newPosition = new Vector2(0.0f, scrollSpeed);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    //code from Tom Tsiliopoulos
    //This will Reset the position of the map if it reaches the end of the boundary
    void Reset()
    {
        transform.position = new Vector2(0.0f, resetPosition);
    }

    //code from Tom Tsiliopoulos
    //This will Chceck Boounds whether if it went over it or not
    void CheckBounds()
    {
        if (transform.position.y <= resetPoint)
        {
            Reset();
        }
    }
}
