using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance = null;

    public int Score;

    public GameObject ChungusManager;

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

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void AddScore(int s)
    {
        GameObject chungus = Instantiate(ChungusManager);
        chungus.GetComponent<ChungusManager>().Trigger(s/100*3);
        Score += s;
        scoreIncreaseDelegate();
    }
}
