using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public AnimalScriptableObject[] animalArray;
    public bool activelySpawning = false;
    private bool waiting = false;

    private void Start()
    {
        Debug.Log(animalArray.Length);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (activelySpawning)
            {
                activelySpawning = false;
            }
            else
            {
                activelySpawning = true;
            }
        }

        if (activelySpawning)
        {
            SpawnAnimals();
        }
    }

    private void SpawnAnimals()
    {
        if (!waiting)
        {
            StartCoroutine(WaitTime());
        }
    }

    IEnumerator WaitTime()
    {
        waiting = true;
        Vector3 randomPos = new Vector3(Random.Range(-20, 21), 0, 30);
        Vector3 rot = new Vector3(0, 180, 0);
        int randm = Random.Range(0, animalArray.Length);
        GameObject anim = Instantiate(animalArray[randm].myAnimal, randomPos, Quaternion.identity);
        anim.transform.eulerAngles = rot;
        anim.GetComponent<MoveForward>().foodName = animalArray[randm].foodName;
        yield return new WaitForSeconds(Random.Range(.5f, 2f));
        waiting = false;
    }
}
