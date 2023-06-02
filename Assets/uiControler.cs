using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIControler : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button startButton;
    public Button messageButton;
    public Label messageText;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        startButton = root.Q<Button>("start-button");
        messageButton = root.Q<Button>("message-button");
        messageText = root.Q<Label>("message-text");
    }

    void StartButtonPressed()
    {
        SceneManager.LoadScene("Main-Scene");
    }

    void MessageButtonPressed()
    {
        messageText.text = "Hello!";
        messageText.style.display = DisplayStyle.Flex;
    }
}
