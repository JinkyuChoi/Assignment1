using System.Collections;
using UnityEngine;
using Util;

//2019-10-06 by Jinkyu Choi
public class SpawnObstacle : MonoBehaviour
{
    //codes from  Wallace Balaniuc
    [Header("Obstacle Controller")]
    public GameObject obstacle;
    public Boundary boundary;

    public float spawnWait;
    public float startWait;

    //codes from  Wallace Balaniuc
    void Start()
    {
        //This will continuously start SpawnObstacles function
        StartCoroutine(SpawnObstacles());
    }

    void Update()
    {

    }

    //codes from  Wallace Balaniuc
    //It is used to control the obstacle, this will instatiate obstacle every spawnWait seconds
    IEnumerator SpawnObstacles()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(boundary.left, boundary.right), boundary.top);
            Instantiate(obstacle, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
