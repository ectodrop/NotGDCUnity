using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    float speed;
    void Start()
    {
        speed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
        if (!IsVisible(Camera.main, GetComponent<SpriteRenderer>().bounds))
        {
            Destroy(this.gameObject);
        }
    }
    private bool IsVisible(Camera camera, Bounds bounds)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        if (GeometryUtility.TestPlanesAABB(planes, bounds))
            return true;
        else
            return false;
    }
}
