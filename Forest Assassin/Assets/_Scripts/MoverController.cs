using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class MoverController : MonoBehaviour
{
    public float scrollSpeed;
    public Boundary boundary;
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
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
        if (transform.position.y >= boundary.top)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject.tag == "PlayerBullet")
        {
            if (other.gameObject.tag == "Obstacle")
            {
                Destroy(this.gameObject);
            }

            if (other.gameObject.tag == "Enemy")
            {

                Destroy(other.gameObject);
                Destroy(this.gameObject);
                gameController.Scores += 100;

            }
        }
    }
}
