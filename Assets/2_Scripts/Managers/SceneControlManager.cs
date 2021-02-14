using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private void Start()
    {
        StartSceneMain();
    }

    public void StartSceneMain()
    {
        _oldSceneType = _nowSceneType;
        _nowSceneType = SceneType.MAIN;

        StartCoroutine(LoadingScene("2_MainScene"));
    }

    public void StartSceneInGame()
    {
        _oldSceneType = _nowSceneType;
        _nowSceneType = SceneType.INGAME;

        StartCoroutine(LoadingScene("TestScene"));
    }

    IEnumerator LoadingScene(string SceneName)
    {
        AsyncOperation aOper;
        Scene aScene;
        // 로딩화면 생성

        _currentStateLoad = LoadingState.LoadSceneStart;
        aOper = SceneManager.LoadSceneAsync(SceneName);
        while (aOper.isDone)
        {
            _currentStateLoad = LoadingState.LoadingScene;
            yield return null;
        }
        _currentStateLoad = LoadingState.LoadSceneEnd;
        aScene = SceneManager.GetSceneByName(SceneName);
        yield return new WaitForSeconds(1);

        SceneManager.SetActiveScene(aScene);

        _currentStateLoad = LoadingState.LoadEnd;
        //로딩화면 삭제

        yield return null;
    }
}
