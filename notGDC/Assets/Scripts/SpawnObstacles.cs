using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public List<GameObject> vehicles = new List<GameObject>();
    public List<GameObject> powerups = new List<GameObject>();

    private Vector3 spawnPosRight, spawnPosLeft;

    public float delay = 0.5f;
    private float delayTimer = 0f, pickupDelayTimer = 0f;
    public float obstacleSpawnChance = 5f;
    public float pickupSpawnChance = 5f;
    public float carSpeed = 6f;


    public float spawnRightY;
    public float spawnLeftY;
    // Start is called before the first frame update\
    void Start()
    {
        delayTimer = delay;
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        spawnPosRight = new Vector3(screenBounds.x, spawnRightY, 0);
        spawnPosLeft = new Vector3(-screenBounds.x, spawnLeftY, 0);
    }
    // Update is called once per frame
    void Update()
    {
        decreaseTime();

        if ((int)Time.time % 10 == 0 && obstacleSpawnChance <= 500)
        {
            obstacleSpawnChance++;
        }
            
        spawnObstaclesSuburb();
        spawnPowerUpsSuburb();
    }
    void spawnObstaclesSuburb()
    {
        bool spawnRateLeft = Random.Range(0,1000f) < obstacleSpawnChance;
        bool spawned = false;
        if (spawnRateLeft && delayTimer <= 0f)
        {
            spawned = true;
            GameObject car = Instantiate(vehicles[1], spawnPosLeft, Quaternion.identity);
            car.gameObject.GetComponent<ObstacleBehaviour>().speed = carSpeed;
        }

        bool spawnRateRight = Random.Range(0, 1000f) < obstacleSpawnChance;
        if (spawnRateRight && delayTimer <= 0f)
        {
            spawned = true;
            GameObject car = Instantiate(vehicles[0], spawnPosRight, Quaternion.identity);
            car.gameObject.GetComponent<ObstacleBehaviour>().speed = -carSpeed;
        }
        if (spawned) delayTimer = delay;

    }

    void spawnPowerUpsSuburb()
    {
        pickupDelayTimer-=Time.deltaTime;
        bool spawnRateRight = Random.Range(0, 1000f) < pickupSpawnChance;
        if (spawnRateRight && pickupDelayTimer <= 0f)
        {
            pickupDelayTimer = delay;
            int offset = Random.Range(0, 2);
            Instantiate(powerups[0], spawnPosRight+Vector3.down*offset, Quaternion.identity);
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
