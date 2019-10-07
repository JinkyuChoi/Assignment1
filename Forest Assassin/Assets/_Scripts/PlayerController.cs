using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

//2019-10-06 by Jinkyu Choi
public class PlayerController : MonoBehaviour
{
    //codes from  Wallace Balaniuc
    [Header("Player Controller")]
    public float speed;
    public Boundary boundary;
    public GameObject attackArea;
    public GameObject attack;
    public float attackSpeed;

    [Header("Game Controller")]
    public GameController gameController;

    [Header("Audio Controller")]
    public AudioSource gunShot;
    public AudioSource hit;


    //private variables
    private Rigidbody2D rBody;
    private float myTime;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    //codes from  Wallace Balaniuc
    void Update()
    {
        //This will restrict player to fire weapon after the attackSpeed second has passed
        myTime += Time.deltaTime;

        if(Input.GetButton("Fire1") && myTime > attackSpeed)
        {
            Instantiate(attack, attackArea.transform.position, attackArea.transform.rotation);
            gunShot.Play();
            myTime = 0.0f;
        }
    }

    //codes from  Wallace Balaniuc
    //This will make user to able to control the character and restrict the character from going out of the camera
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        rBody.velocity = movement * speed;

        rBody.position = new Vector2(
            Mathf.Clamp(rBody.position.x, boundary.left, boundary.right),
            Mathf.Clamp(rBody.position.y, boundary.bottom, boundary.top));
    }

    //code from Tom Tsiliopoulos
    //This will check if Enemy, EnemyBullet, Obstacle has collide with player and make Lives decrease
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "EnemyBullet" || other.gameObject.tag == "Enemy") 
        {
            gameController.Lives -= 1;
            hit.Play();
         
        }
    }
}
