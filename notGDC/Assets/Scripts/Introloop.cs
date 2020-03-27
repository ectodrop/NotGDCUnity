using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introloop : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource musicIntro, musicLoop;
    void Start()
    {
        musicIntro.Play();
        musicLoop.PlayDelayed(musicIntro.clip.length);
    }

    // Update is called once per frame
}
