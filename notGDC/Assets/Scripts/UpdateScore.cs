﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    // Start is called before the first frame update
    public int scoreCount = 0;
    TMPro.TextMeshProUGUI score;
    void Start()
    {
        score = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreCount;
    }
}