using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    CameraScript  cs;
    private float maxHorizontal , maxVertical;
    public GameObject asteroidPrefab;
    public float spawnInterval = 3;
    public float spawnTimer = 3;
   


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        maxHorizontal = cs.worldWidith / 2 * 1.2f;
        maxVertical = cs.worldHeight / 2 * 1.2f;
    }
    void spawn()
    {

        float randomX, randomZ;


        if (Mathf.Round(Random.Range(0, 1)) == 0)
        {
            randomZ = Mathf.Round(Random.Range(0, 1)) * maxVertical;
            randomX = Random.Range(0, maxHorizontal);
        }
        else
        {
            randomX = Mathf.Round(Random.Range(0, 1)) * maxHorizontal;
            randomZ = Random.Range(0, maxVertical);
        }
        Vector3 spawnPoint = new Vector3(randomX, 0, randomZ);
        Instantiate(asteroidPrefab, spawnPoint, Quaternion.identity);

    }
}
