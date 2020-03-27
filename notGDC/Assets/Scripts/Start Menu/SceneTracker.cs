using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTracker : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static int previousSceneIndex { get; set; }
    void Start()
    {
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

}
