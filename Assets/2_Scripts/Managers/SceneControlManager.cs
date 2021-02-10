using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using System;

public class SceneControlManager : MonoBehaviour
{
    enum SceneType
    {
        MAIN,
        INGAME
    }

    public enum LoadingState
    {
        none = 0,

        LoadSceneStart,
        LoadingScene,
        LoadSceneEnd,

        LoadStageStart,
        LoadingStage,
        LoadStageEnd,
        LoadEnd
    }

    SceneType _nowSceneType;
    SceneType _oldSceneType;
    LoadingState _currentStateLoad;

    static SceneControlManager _uniqueInstance;

    public static SceneControlManager _instance
    {
        get { return _uniqueInstance; }
    }

    private void Awake()
    {
        _uniqueInstance = this;
        DontDestroyOnLoad(gameObject);
    }

    IEnumerator LoadingScene(string SceneName)
    {
        AsyncOperation async;
        Scene aScene;

        yield return null;
    }
}
