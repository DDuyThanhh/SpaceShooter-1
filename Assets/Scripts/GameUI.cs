using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject gameUI;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject playerStartPosition;

    private void Start()
    {
        DelayMainMenuDisplay();   
    }

    private void OnEnable()
    {
        EventManager.onStartGame += ShowGameUI;
        EventManager.onPlayerDead += ShowMainMenu;
    }
    private void OnDisable()
    {
        EventManager.onStartGame -= ShowGameUI;
        EventManager.onPlayerDead -= ShowMainMenu;
    }

    void ShowMainMenu()
    {
        Invoke("DelayMainMenuDisplay", Asteroid.destructionDelay * 3);
    }

    void DelayMainMenuDisplay()
    {
        mainMenu.SetActive(true);
        gameUI.SetActive(false);
    }

    void ShowGameUI()
    {
        mainMenu.SetActive(false);
        gameUI.SetActive(true);

        Instantiate(playerPrefab, playerStartPosition.transform.position, playerStartPosition.transform.rotation);
    }
}
