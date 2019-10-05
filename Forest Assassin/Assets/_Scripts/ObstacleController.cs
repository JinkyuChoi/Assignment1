using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class ObstacleController : MonoBehaviour
{
    public float scrollSpeed;

    public Boundary boundary;

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

    void CheckBounds()
    {
        if (transform.position.y <= boundary.bottom)
        {
            Destroy(this.gameObject);
        }
    }
}
