using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAttack : MonoBehaviour
{
    public GameObject attack;
    public GameObject attackArea;
    public int attackCount;
    public float spawnWait;

    public AudioSource attackSound;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            for (int i = 0; i < attackCount; i++)
            {
                Instantiate(attack, attackArea.transform.position, attackArea.transform.rotation);
                attackSound.Play();
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }
}
