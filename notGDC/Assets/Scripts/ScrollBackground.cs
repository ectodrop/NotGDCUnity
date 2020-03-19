using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    // Start is called before the first frame update
    private float length;
    private float speed = 1f;
    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        speed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
    
        if (transform.position.x < -length) 
        {
            transform.position += new Vector3(length*2f, 0, 0);
        }

        transform.position += Vector3.left * Time.deltaTime * speed;
    }
    
}
