using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Public UI button elements 
    public Button signoutButton;
    public Button quizButton;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize signout Button and add a listener for if its clicked
        Button signoutBtn = signoutButton.GetComponent<Button>();
        signoutBtn.onClick.AddListener(signoutButtonClicked);

        // Initialize quiz Button and add a listener for if its clicked
        Button quizBtn = quizButton.GetComponent<Button>();
        quizBtn.onClick.AddListener(quizButtonClicked);
    }

    // Check if signout button is clicked
    void signoutButtonClicked()
    {
        // Go to login scene
        SceneManager.LoadScene("LoginScene");
    }

    // Check if quiz button is clicked
    void quizButtonClicked()
    {
        // Go to quiz scene
        SceneManager.LoadScene("QuizScene");
    }
}
