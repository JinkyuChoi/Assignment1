using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

//2019-10-06 by Jinkyu Choi
public class MoverController : MonoBehaviour
{
    //code from Tom Tsiliopoulos
    [Header("Movement Controller")]
    public float scrollSpeed;
    public Boundary boundary;

    [Header("Audio Controller")]
    public AudioSource obstacleHit;
    public AudioSource enemyHit;

    public GameController gameController;

    //codes from  Wallace Balaniuc
    void Start()
    {
        //This will make variable gameController to able to get GameController
        //It is used to access to variable in GameController, Scores
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    //code from Tom Tsiliopoulos
    void Update()
    {
        Move();
        CheckBounds();
    }


    //code from Tom Tsiliopoulos
    //This will scroll the mover object
    void Move()
    {
        Vector2 newPosition = new Vector2(0.0f, scrollSpeed);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    //code from Tom Tsiliopoulos
    //This will Check the bound. If it crosses the bound, this will destroy that object
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

    //codes from  Wallace Balaniuc
    //This will check collision between objects and able to do functions thatis assigned to it
    //It is used to check the player bullet is hitting Obstacle or Enemy, If it is Enemy it will add the Score
    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject.tag == "PlayerBullet")
        {
            if (other.gameObject.tag == "Obstacle")
            {
                gameController.obstacleHit.Play();
                Destroy(this.gameObject);
            }

            if (other.gameObject.tag == "Enemy")
            {
                gameController.enemyHit.Play();
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                gameController.Scores += 100;

            }
        }
    }
}
