using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    float speed;
    float halfWidth, halfHeight;
    void Start()
    {

        halfWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        halfHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        Debug.Log(halfWidth);
        speed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
        if (AtEdge())
        {
            Destroy(this.gameObject);
        }
    }
    private bool AtEdge()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        if (transform.position.x < -screenBounds.x -halfWidth||
          transform.position.x > screenBounds.x + halfWidth||
          transform.position.y < -screenBounds.y - halfHeight ||
          transform.position.y > screenBounds.y + halfHeight)
        {
            return true;
        }
        return false;
    }
}
