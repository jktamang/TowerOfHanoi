using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    private GameObject rulesUI;
    private GameObject mainUI;
    private GameObject victoryUI;
    private GameObject mouseManager;
    private CursorManager cursorManager;
    private EventSystem eventSystem;

    void Start()
    {
        eventSystem = EventSystem.current;
        rulesUI = GameObject.Find("RulesUI");
        mainUI = GameObject.Find("MainUI");
        victoryUI = GameObject.Find("VictoryUI");
        mouseManager = GameObject.Find("MouseManager");
        GameObject  cursor = GameObject.Find("Cursor");

        if (cursor) cursorManager = cursor.GetComponent<CursorManager>();
        if (victoryUI) victoryUI.SetActive(false);
        if (rulesUI) rulesUI.SetActive(false);
    }

    public void ToggleRulesUI()
    {
        if (rulesUI.activeSelf)
        {
            if (mouseManager)   mouseManager.SetActive(true);
            if (cursorManager)  cursorManager.enabled = true;
            if (mainUI)         mainUI.SetActive(true);
            
            rulesUI.SetActive(false);

            GameObject rulesButton = GameObject.Find("RulesButton");

            if (rulesButton) eventSystem.SetSelectedGameObject(rulesButton);
        }
        else
        {
            if (mouseManager)   mouseManager.SetActive(false);
            if (cursorManager)  cursorManager.enabled = false;
            if (mainUI)         mainUI.SetActive(false);
            
            rulesUI.SetActive(true);

            eventSystem.SetSelectedGameObject(
                GameObject.Find("BackButton"));
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && rulesUI)
        {
            ToggleRulesUI();
        }
    }

    public void HideMainUI()
    {
        if (mainUI) mainUI.SetActive(false);
    }

    public void ShowMainUI()
    {
        if (mainUI) mainUI.SetActive(true);
    }

    public void ShowVictoryUI()
    {
        if (mainUI) mainUI.SetActive(false);
        if (victoryUI)
        {
            victoryUI.SetActive(true);
            eventSystem.SetSelectedGameObject(
                GameObject.Find("RetryButton"));
        }

    }

    public void HideVictoryUI()
    {
        if (victoryUI) victoryUI.SetActive(false);
    }
}
