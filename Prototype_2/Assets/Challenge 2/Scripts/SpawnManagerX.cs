using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30f;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;
    bool waiting = false;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    private void Update()
    {
        if (!waiting)
        {
            StartCoroutine(WaitTime());
        }
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[Random.Range(0, ballPrefabs.Length -1)], spawnPos, ballPrefabs[0].transform.rotation);
    }

    IEnumerator WaitTime()
    {
        waiting = true;
        SpawnRandomBall();
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        waiting = false;
    }

}
