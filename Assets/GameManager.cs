using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int N = 3;
    private StacksManager stacksManager;
    private bool hasGameEnded = false;
    private UIManager uiManager;

    void EndGame()
    {
        hasGameEnded = true;
        Destroy(GameObject.Find("Cursor").GetComponent<CursorManager>());
        Destroy(GameObject.Find("MouseManager"));
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
        uiManager.ShowVictoryUI();
    }

    void Start()
    {
        GameObject gameSettings = GameObject.Find("GameSettings");
        if (gameSettings != null)
        {
            N = gameSettings.GetComponent<GameSettings>().DisksNum;
        }
        stacksManager = GetComponent<StacksManager>();
        stacksManager.Initialize(N);
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    void Update()
    {
        if (!hasGameEnded && stacksManager.isFinished())
        {
            EndGame();
        }
    }
}
