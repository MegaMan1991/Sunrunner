using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;



public class MainMenuEvents : MonoBehaviour
{
    private UIDocument _document;
    private Button _button;

    [SerializeField] private string _startLevelName;

    private List<Button> _menuButtons = new List<Button>();
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _document = GetComponent<UIDocument>();

        _button = _document.rootVisualElement.Q("StartGameButton") as Button;
        _button.RegisterCallback<ClickEvent>(OnPlayGameClick);

        _menuButtons = _document.rootVisualElement.Query<Button>().ToList();
        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

private void OnDisable()
    {
        _button.UnregisterCallback<ClickEvent>(OnPlayGameClick);
    }

    private void OnPlayGameClick(ClickEvent evt)
    {
        Debug.Log("You pressed the Start Button");
        SceneManager.LoadScene(_startLevelName);
    }

    private void OnAllButtonsClick(ClickEvent evt)
    {
        Debug.Log("Button successfully clicked");
        _audioSource.Play();
    }
}


