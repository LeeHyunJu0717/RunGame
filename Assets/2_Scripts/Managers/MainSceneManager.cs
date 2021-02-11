using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    public void ClickPlayButton()
    {
        SceneControlManager._instance.StartSceneInGame();
    }

    public void ClickTotalScoreButton()
    {

    }
}
