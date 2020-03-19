using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public List<GameObject> vehicles = new List<GameObject>();
    public Transform spawnerLeft, spawnerRight;
    
    public float waveTime = 3.0f;
    private float waveTimer;

    public float spawnChance = 5f;
    // Start is called before the first frame update\

    // Update is called once per frame
    void Update()
    {
        spawnObjectsSuburb();
    }
    void spawnObjectsSuburb()
    {
        bool spawnRateLeft = Random.Range(1f,1000f) < spawnChance;

        if (spawnRateLeft)
        {
            GameObject car = Instantiate(vehicles[0], spawnerLeft);
            car.gameObject.GetComponent<ObstacleBehaviour>().speed = 6;
        }

        bool spawnRateRight = Random.Range(1f, 1000f) < spawnChance;
        if (spawnRateRight)
        {
            GameObject car = Instantiate(vehicles[0], spawnerRight);
            car.gameObject.GetComponent<ObstacleBehaviour>().speed = -6;
        }

    }
}
