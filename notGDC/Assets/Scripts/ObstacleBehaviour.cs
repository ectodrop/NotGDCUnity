using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = -2.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + speed*Time.deltaTime, transform.position.y, transform.position.z); 
        if(!IsVisible(Camera.main, GetComponent<Renderer>().bounds))
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
