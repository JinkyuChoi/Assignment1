using System.Collections;
using UnityEngine;

//2019-10-06 by Jinkyu Choi
public class SpawnAttack : MonoBehaviour
{
    //codes from  Wallace Balaniuc
    [Header("Attack Controller")]
    public GameObject attack;
    public GameObject attackArea;
    public float attackWait;

    [Header("Audio Controller")]
    public AudioSource attackSound;

    //codes from  Wallace Balaniuc

    void Start()
    {
        //This will continuously start SpawnAttack function
        StartCoroutine(SpawnAttacks());
    }


    void Update()
    {

    }

    //codes from  Wallace Balaniuc
    //This will spawn attack
    //It is used to control the attack of the enemies, this will instatiate enemy attack every attackWait seconds
    IEnumerator SpawnAttacks()
    {
        while (true)
        {
            Instantiate(attack, attackArea.transform.position, attackArea.transform.rotation);
            attackSound.Play();
            yield return new WaitForSeconds(attackWait);
        }
    }
}
