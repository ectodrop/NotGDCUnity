using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public List<GameObject> vehicles = new List<GameObject>();
    public List<GameObject> powerups = new List<GameObject>();
    public Transform spawnerLeft, spawnerRight;

    public float delay = 0.5f;
    private float delayTimer = 0f;
    public float obstacleSpawnChance = 5f;
    public float pickupSpawnChance = 5f;

    public int interval = 1;
    // Start is called before the first frame update\
    void Start()
    {
        delayTimer = delay;
    }
    // Update is called once per frame
    void Update()
    {
        decreaseTime();

        if (Time.time-10*interval <= 0)
        {
            interval++;
            obstacleSpawnChance++;
        }
            
        spawnObstaclesSuburb();
        spawnPowerUpsSuburb();
    }
    void spawnObstaclesSuburb()
    {
        bool spawnRateLeft = Random.Range(0,1000f) < obstacleSpawnChance;

        if (spawnRateLeft && delayTimer <= 0f)
        {
            delayTimer = delay;
            GameObject car = Instantiate(vehicles[1], spawnerLeft);
            car.gameObject.GetComponent<ObstacleBehaviour>().speed = 6;
        }

        bool spawnRateRight = Random.Range(0, 1000f) < obstacleSpawnChance;
        if (spawnRateRight && delayTimer <= 0f)
        {
            delayTimer = delay;
            GameObject car = Instantiate(vehicles[0], spawnerRight);
            car.gameObject.GetComponent<ObstacleBehaviour>().speed = -6;
        }

    }

    void spawnPowerUpsSuburb()
    {

        bool spawnRateRight = Random.Range(0, 1000f) < pickupSpawnChance;
        if (spawnRateRight && delayTimer == 0f)
        {
            delayTimer = delay;
            int offset = Random.Range(0, 2);
            Instantiate(powerups[0], spawnerRight.position+Vector3.left+Vector3.down*offset, Quaternion.identity);
        }
    }

    void decreaseTime()
    {
        if(delayTimer>0) delayTimer -= Time.deltaTime;
        if(delayTimer <= 0f)
        {
            delayTimer = 0f;
        }
    }
}
