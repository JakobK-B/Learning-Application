using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{
    // Public UI button elements
    public Button submitButton;
    public Button exitButton;

    // Public UI text elements
    public Text resultText;

    // Public UI input field elements
    public InputField inputUsername;
    public InputField inputPassword;

    // Private string varibles
    private string sampleUsername = "User1";
    private string samplePassword = "Password1";


    // Start is called before the first frame update
    void Start()
    {
        // At the start of the scene the result is blank
        resultText.text = " ";

        // Initialize Submit Button and add a listener for if its clicked
        Button submitBtn = submitButton.GetComponent<Button>();
        submitBtn.onClick.AddListener(SubmitButtonClicked);

        // Initialize Exit Button and add a listener for if its clicked
        Button exitBtn = exitButton.GetComponent<Button>();
        exitBtn.onClick.AddListener(exitButtonClicked);
    }

    // Check login infomation is submit login is clicked
    void SubmitButtonClicked()
    {
        // Get current input fields values
        string inputedUsername = inputUsername.text;
        string inputedPassword = inputPassword.text;


        // Check if the inputed login is valid 
        if ((inputedPassword == samplePassword) && (inputedUsername == sampleUsername))
        {
            // Go to main menu as login succesful
            SceneManager.LoadScene("MenuScene");
        }
        else
        {
            // State either username or password is incorrect for security reasons  
            resultText.text = "Login infomation invalid";
        }
    }

    // Exit Application if exit button clicked
    void exitButtonClicked()
    {
        // Unity inbuilt function to close application
        Application.Quit();
        print("Closed");
    }
}
