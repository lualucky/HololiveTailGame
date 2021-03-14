using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance = null;

    public int Chances;
    public int AllowedMisses;

    public GameObject UI;
    public GameObject LifeUI;

    public GameObject LoseScreen;
    public GameObject WinScreen;

    public GameObject Player;

    private Transform LifeParent;

    public static LevelManager Instance
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
    }


    private void Start()
    {
        LifeParent = new GameObject("Life Parent").transform;
        LifeParent.SetParent(UI.transform, false);


        Vector3 pos = new Vector3(350, 175, 0);

        for(int i = 0; i < Chances; ++i)
        {
            GameObject o = Instantiate(LifeUI);
            o.transform.SetParent(LifeParent, false);
            o.GetComponent<RectTransform>().anchoredPosition = pos;
            pos = pos - new Vector3(100, 0, 0);
        }
    }
    public void Hit(bool hit)
    {
        if (!hit)
            --AllowedMisses;
        --Chances;
        if (Chances == 0)
            EndLevel();

        Destroy(LifeParent.GetChild(LifeParent.childCount - 1).gameObject);
    }

    public void EndLevel()
    {
        if (AllowedMisses <= 0)
            Lose();
        else
            Win();
        Player.SetActive(false);
    }

    public void Lose()
    {
        UI.SetActive(false);
        LoseScreen.SetActive(true);
    }
    public void Win()
    {
        UI.SetActive(false);
        WinScreen.SetActive(true);
    }
}
