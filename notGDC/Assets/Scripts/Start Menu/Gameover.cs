using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gameover : MonoBehaviour
{
    // Start is called before the first frame update
    private static int highscoreValue = 0;
    public TMPro.TextMeshProUGUI highscore;
    public TMPro.TextMeshProUGUI score;
    void Start()
    {
        
        score.text = "Score: " +  UpdateScore.scoreCount.ToString();

        if(UpdateScore.scoreCount > highscoreValue)
        {
            highscoreValue = UpdateScore.scoreCount;
        }
        highscore.text = "Highscore: " +  highscoreValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneTracker.previousSceneIndex);
        }
    }
}
