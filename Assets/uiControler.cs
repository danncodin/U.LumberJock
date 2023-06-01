// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UIElements;

// public class uiControler : MonoBehaviour
// {
//     public Button startButton;
//     public Button messageButton;
//     public Label messageText;

//     void Start()
//     {
//         var root = GetComponent<UIDocument>().rootVisualElement;

//         startButton = root.Q<Button>("start-button");
//         messageButton = root.Q<Button>("message-button");
//         messageText = root.Q<Label>("message-text");
//     }

//     void StartButtonPressed()
//     {
//         SceneManager.LoadScene("game");
//     }

//     void MessageButtonPressed()
//     {

//     }
// }
