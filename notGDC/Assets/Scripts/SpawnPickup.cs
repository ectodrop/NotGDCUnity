using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickup : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> powerups = new List<GameObject>();
    public GameObject spawner;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObject()
    {
        int lane = Random.Range(-2, 3);
        Vector3 spawnPos = new Vector3(spawner.transform.position.x, lane, spawner.transform.position.z);
        Instantiate(powerups[0], spawnPos, Quaternion.identity);
    }
}
