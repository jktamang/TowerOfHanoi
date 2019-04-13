using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    private UIManager uiManager;

    void Start()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

	public void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void GameStart(int disksNum)
	{
		GameObject gameSettings = GameObject.Find("GameSettings");
		gameSettings.GetComponent<GameSettings>().DisksNum = disksNum;
		SceneManager.LoadScene("MainGame");
	}

    public void ToggleRules()
    {
        uiManager.ToggleRulesUI();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ToggleAudio()
    {
        if (AudioListener.pause)
        {
            gameObject.GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Sprites/button_audio");
        }
        else
        {
            gameObject.GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Sprites/button_audio_x");
        }

        AudioListener.pause = !AudioListener.pause;
    }
}
