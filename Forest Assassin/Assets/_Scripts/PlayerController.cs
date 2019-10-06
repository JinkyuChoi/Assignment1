using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Boundary boundary;
    public GameObject attackArea;
    public GameObject attack;

    public float attackSpeed;
    public float myTime;
    public GameController gameController;
    public AudioSource gunShot;
    public AudioSource hit;

    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myTime += Time.deltaTime;

        if(Input.GetButton("Fire1") && myTime > attackSpeed)
        {
            Instantiate(attack, attackArea.transform.position, attackArea.transform.rotation);
            gunShot.Play();
            myTime = 0.0f;
        }
    }
    
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "EnemyBullet" || other.gameObject.tag == "Enemy") 
        {
            gameController.Lives -= 1;
            hit.Play();
         
        }
    }
}
