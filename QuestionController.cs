using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionController : MonoBehaviour
{
    // State public Button gameObjects
    public Button ButtonA;
    public Button ButtonB;
    public Button ButtonC;
    public Button ButtonD;
    public Button menuButton;

    // State public Text gameObjects
    public Text questionText;
    public Text TextA;
    public Text TextB;
    public Text TextC;
    public Text TextD;
    public Text TextScore;

    // State public Slider gameObjects
    public Slider ScoreSlider;
    public Slider TimerSlider;

    // State public float varibles
    public float timerInterval = 0.1f;
    public float timerMax = 3f;

    // State private float varibles
    private float timerCurrent;

    // State private integer varibles 
    private int currentRightAnswer;
    private int score;
    private int attempts = -1;
    private int correctAttempts;

    // Start is called before the first frame update
    void Start()
    {
        // Call a new question at the start of the test
        GetQuestion();

        // Initialize Button A and add a listener for if its clicked
        Button btnA = ButtonA.GetComponent<Button>();
        btnA.onClick.AddListener(ButtonAClicked);

        // Initialize Button B and add a listener for if its clicked
        Button btnB = ButtonB.GetComponent<Button>();
        btnB.onClick.AddListener(ButtonBClicked);

        // Initialize Button C and add a listener for if its clicked
        Button btnC = ButtonC.GetComponent<Button>();
        btnC.onClick.AddListener(ButtonCClicked);

        // Initialize Button D and add a listener for if its clicked
        Button btnD = ButtonD.GetComponent<Button>();
        btnD.onClick.AddListener(ButtonDClicked);

        // Initialize Menu Button and add a listener for if its clicked
        Button menuBtn = menuButton.GetComponent<Button>();
        menuBtn.onClick.AddListener(MenuButtonClicked);

        // Reset the realtime timer to its maximum
        timerCurrent = timerMax;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Update the realtime timer at fixed intervals and change the timeer slider according
        timerCurrent -= timerInterval;
        TimerSlider.value = timerCurrent / timerMax;

        // Update the text score to show correct answers and attempts
        TextScore.text = correctAttempts.ToString() + "/" + attempts.ToString();

        // if the timer reaches zero return an incorrect answer and call a new question
        if (timerCurrent <= 0)
        {
            incorrect();
            reset();
        }

        // If the score is ever asked to go below zero it is reset back to stay at zero
        if (score <= 0)
        {
            score = 0;
        }

        // Convert the integer score to a float so that the score slider can be valued by floats
        float fScore  = (float)score;
        ScoreSlider.value = fScore / 100f;
    }

    // Function to generate a random question and answer so they can be eaisly returned 
    void GetQuestion()
    {
        // Get a random number to generate the type of question addition, subtraction or multiplcation
        int type = Random.Range(1, 3);
        type = 0;

        // Creat a list of integers that will hold the two question values and the answer
        List<int> question;
        if (type == 1)
        {
            // Populate the empty list with a randomly generated quesiton and answer
            question = Addition();
        }
        question = Addition();

        // Display the question as text to the user 
        string finalQuestion = question[0].ToString() + " + " + question[1].ToString() + " = ?";
        questionText.text = finalQuestion;

        // Set a random button (A, B, C or D) as the correct Answer
        int correctAnswerButton = Random.Range(1, 5);

        // Set the text of the 'Correct' button to be the correct answer
        // As or the rest of the questions a wrong answer will be generated for each of them
        if (correctAnswerButton == 1)
        {
            TextA.text = question[2].ToString();
            TextB.text = (question[2] + getWrongAnswer()).ToString();
            TextC.text = (question[2] + getWrongAnswer()).ToString();
            TextD.text = (question[2] + getWrongAnswer()).ToString();

        }
        else if (correctAnswerButton == 2)
        {
            TextA.text = (question[2] + getWrongAnswer()).ToString();
            TextB.text = question[2].ToString();
            TextC.text = (question[2] + getWrongAnswer()).ToString();
            TextD.text = (question[2] + getWrongAnswer()).ToString();
        }
        else if (correctAnswerButton == 3)
        {
            TextA.text = (question[2] + getWrongAnswer()).ToString();
            TextB.text = (question[2] + getWrongAnswer()).ToString();
            TextC.text = question[2].ToString();
            TextD.text = (question[2] + getWrongAnswer()).ToString();
        }
        else if (correctAnswerButton == 4)
        {
            TextA.text = (question[2] + getWrongAnswer()).ToString();
            TextB.text = (question[2] + getWrongAnswer()).ToString();
            TextC.text = (question[2] + getWrongAnswer()).ToString();
            TextD.text = question[2].ToString();
        }

        // Set the global correct answer to the generated correct answer button
        currentRightAnswer = correctAnswerButton;

        // Add an attempt for each question asked
        attempts++;
    }

    // Generate a random value to change the correct answer by to make incorrect answers
    int getWrongAnswer()
    {
        int wrongAnswer = 0;

        // While loop prevents the generator from returning the correct answer as a 'wrong' answer
        while (wrongAnswer == 0)
        {
            wrongAnswer = Random.Range(-50, 50);
        }
        return wrongAnswer;
    }

    // Addition question generator that returns a list of the two values and the correct answer
    List<int> Addition()
    {
        List<int> question = new List<int>();
        int numA = Random.Range(0, 100);
        int numB = Random.Range(0, 100);
        int numC = numA + numB;
        question.Add(numA);
        question.Add(numB);
        question.Add(numC);
        return question;
    }

    // Check if button A is clicked
    void ButtonAClicked()
    {
        // Checks if button A was correct
        if (currentRightAnswer == 1)
        {
            correct();
            reset();
        }
        else
        {
            incorrect();
            reset();
        }
    }

    // Check if button B is clicked
    void ButtonBClicked()
    {
        // Checks if button B was correct
        if (currentRightAnswer == 2)
        {
            correct();
            reset();
        }
        else
        {
            incorrect();
            reset();
        }
    }

    // Check if button C is clicked
    void ButtonCClicked()
    {
        // Checks if button C was correct
        if (currentRightAnswer == 3)
        {
            correct();
            reset();
        }
        else
        {
            incorrect();
            reset();
        }
    }

    // Check if button D is clicked
    void ButtonDClicked()
    {
        // Checks if button D was correct
        if (currentRightAnswer == 4)
        {
            correct();
            reset();
        }
        else
        {
            incorrect();
            reset();
        }
    }

    // Check if menu button is clicked
    void MenuButtonClicked()
    {
        SceneManager.LoadScene("MenuScene");
    }

    // If the correct answer was clicked increase the score and add a correct attempt
    void correct()
    {
        score += 8;
        correctAttempts++;
    }

    // If the user was incorrect deduct the score 
    void incorrect()
    {
        score -= 10;
    }

    // Resets the test system by calling a new question and reseting the timer to the max
    void reset()
    {
        GetQuestion();
        timerCurrent = timerMax;
    }
}