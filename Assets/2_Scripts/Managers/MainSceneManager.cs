using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField] Transform parent;
    GameObject ScoreWindow;

    private void Awake()
    {
        ScoreWindow = Resources.Load("TotalScore Window") as GameObject;
    }

    public void ClickPlayButton()
    {
        SceneControlManager._instance.StartSceneInGame();
    }

    public void ClickTotalScoreButton()
    {
        if (GameObject.Find("TotalScore Window"))
            ScoreWindow.SetActive(true);
        else
            Instantiate(ScoreWindow, parent);
    }
}
