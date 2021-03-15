using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text Score;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.scoreIncreaseDelegate += ScoreChange;
        Score.text = "" + ScoreManager.Instance.Score;
    }

    public void ScoreChange()
    {
        Score.text = "" + ScoreManager.Instance.Score;
    }
    public void OnDestroy()
    {
        ScoreManager.scoreIncreaseDelegate -= ScoreChange;
    }
}
