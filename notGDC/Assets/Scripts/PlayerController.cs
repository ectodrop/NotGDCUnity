using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 pos;                                // For movement
    public float scrollSpeed = 1.0f;
    
    public float speed = 2.0f;                         // Speed of movement
    public Camera cam;
    public float units = 1.0f;

    public UpdateScore updater;
    public GameObject obstacle;
    public float yMax, yMin, xMax, xMin;
    private float score;
    void Start()
    {
        pos = transform.position;          // Take the initial position
    }
    
    
    void FixedUpdate()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Vector3 test, direction;
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position == pos )
        {
            direction = Vector3.right * units;
            test = transform.position + direction;
            if (test.x < screenBounds.x-xMax)
            {
                pos += direction;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position == pos)
        {
            direction = Vector3.left * units;
            test = transform.position + direction;
            if (test.x > -screenBounds.x+xMin)
            {
                pos += direction;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position == pos)
        {
            direction = Vector3.up * units;
            test = transform.position + direction;
            if (test.y < screenBounds.y-yMax)
            {
                pos += direction;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position == pos)
        {
            direction = Vector3.down * units;
            test = transform.position + direction;
            if (test.y > -screenBounds.y+yMin)
            {
                pos += direction;
            }
        }
        
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        score += Time.deltaTime;
        if (score >= 1f)
        {
            score = 0;
            updater.scoreCount++;
        }

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Obstacle")){
            Debug.Log("DEAD");
        }
        if (coll.CompareTag("Pickup"))
        {
            updater.scoreCount += 10;
            Destroy(coll.gameObject);
        }
    }
}