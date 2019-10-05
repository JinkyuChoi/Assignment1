using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject obstacle;  // What are we spawning?
    public Boundary boundary; // Where do we spawn our hazards?
    public int obstacleCount; // How many hazards per wave?
    public float spawnWait; // How long between each hazard in each wave?
    public float waveWait;

    public bool gameOver;
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
        //Delay until first wave appers
        while (true)
        {
            // Spawning our hazards
            for (int i = 0; i < obstacleCount; i++)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(-7, 7), 22);
                //                                     11                    -4         4
                Instantiate(obstacle, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait); // Wait time between spawning each hazard
            }
            yield return new WaitForSeconds(waveWait); // Delay between each wave of hazard

            if (gameOver)
            {
                break; // Stops any more waves from being generated
            }
        }
    }
}
