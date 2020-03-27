using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = -2.0f;
    float halfWidth, halfHeight;
    void Start()
    {

        halfWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        halfHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }
        // Update is called once per frame
        void Update()
    {
        transform.position = new Vector3(transform.position.x + speed*Time.deltaTime, transform.position.y, transform.position.z);
        if (AtEdge())
        {
            Destroy(this.gameObject);
        }
    }

    private bool AtEdge()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        if (transform.position.x < -screenBounds.x - halfWidth ||
          transform.position.x > screenBounds.x + halfWidth ||
          transform.position.y < -screenBounds.y - halfHeight ||
          transform.position.y > screenBounds.y + halfHeight)
        {
            return true;
        }
        return false;
    }
}
