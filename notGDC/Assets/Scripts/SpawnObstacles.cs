using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public List<GameObject> vehicles = new List<GameObject>();
    public Transform spawner;

    public float waveTime = 3.0f;
    private float waveTimer;
    // Start is called before the first frame update
    void Start()
    {
        waveTimer = waveTime;
        spawnObjects();
    }

    // Update is called once per frame
    void Update()
    {
        waveTimer -= Time.deltaTime;
        if(waveTimer <= 0)
        {
            waveTimer = waveTime;
            spawnObjects();
        }
    }
    void spawnObjects()
    {
        int exclude = Random.Range(-2, 3);

        for (int i = -2; i <= 2; i++)
        {
            if (i == exclude) continue;
            Vector3 spawnPos = spawner.position;
            spawnPos.y = 0;
            spawnPos.y += i;
            Instantiate(vehicles[0], spawnPos, Quaternion.identity);
        }
    }
}
