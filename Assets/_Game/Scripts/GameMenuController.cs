using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameMenuController : MonoBehaviour
{
    private VisualElement root;
    private VisualElement gameplayMenu;
    private VisualElement pauseMenu;

    private Button pauseButton;
    private Button quitButton;

    void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        gameplayMenu = root.Q("GameplayMenuVisualTree");
        pauseMenu = root.Q("PauseMenuVisualTree");

        pauseButton = root.Q<Button>("PauseButton");
        quitButton = root.Q<Button>("QuitButton");

        pauseButton?.RegisterCallback<ClickEvent>(ShowPauseMenu);  // Using null-conditional operator
        quitButton?.RegisterCallback<ClickEvent>(QuitToMainMenu); // Using null-conditional operator

        // Initially hide the pause menu
        pauseMenu.style.display = DisplayStyle.None;
    }

    private void ShowPauseMenu(ClickEvent evt)
    {
        gameplayMenu.style.display = DisplayStyle.None;
        pauseMenu.style.display = DisplayStyle.Flex; // Or DisplayStyle.Block, depending on your layout
    }

    private void QuitToMainMenu(ClickEvent evt)
    {
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with your main menu scene name
    }
}