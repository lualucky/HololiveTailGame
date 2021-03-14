using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScreen : MonoBehaviour
{
    public Text HighScore;
    public Text Score;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.Instance.GameEnd();
        HighScore.text = "High Score: " + ScoreManager.Instance.GetHighScore();
        Score.text = "Score: " + ScoreManager.Instance.Score;
    }
}
