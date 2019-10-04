using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public float scrollSpeed;
    public float resetPosition;
    public float resetPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    void Move()
    {
        Vector2 newPosition = new Vector2(0.0f, scrollSpeed);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    void Reset()
    {
        transform.position = new Vector2(0.0f, resetPosition);
    }

    void CheckBounds()
    {
        if (transform.position.y <= resetPoint)
        {
            Reset();
        }
    }
}
