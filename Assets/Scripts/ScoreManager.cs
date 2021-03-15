using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;

    public int Score;

    public GameObject ChungusManager;

    public int HighScore;

    public delegate void ScoreIncrease();
    public static ScoreIncrease scoreIncreaseDelegate;

    public static ScoreManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void AddScore(int s)
    {
        Score += s;
        Debug.Log("Score: " + Score);
        scoreIncreaseDelegate();
        GameObject chungus = Instantiate(ChungusManager);
        chungus.GetComponent<ChungusManager>().Trigger(s/100*3);
    }

    public bool GameEnd()
    {
        bool result = false;
        if(Score > HighScore)
        {
            result = true;
        }

        HighScore = Mathf.Max(Score, HighScore);
        return result;
    }

    public int GetHighScore()
    {
        return HighScore;
    }
}