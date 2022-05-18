using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Balls[] startBalls;

    public List<Balls> activeBalls;

    public FinishEvents finishEvents;

    float requiredBallPercentage;
    float requiredTimerPercentage;
    public int completePercentage;
    bool levelCompleted;
    bool levelFailed;
    float timer = 4;
    bool startTimer;
    int second;
    int splitSecond;
    public bool gameSetted;
    bool levelCompleteEvents;
    bool levelFailedEvents;

    //UI
    public TextMeshProUGUI completePercentageText;
    public GameObject fireWork;
    public GameObject blackBackground;
    public GameObject levelCompletedText;
    public GameObject levelFailedText;
    public GameObject tapToContinueButton;
    public GameObject tapToRestart;
    public TextMeshProUGUI timerText;
    
    


    private void Start()
    {
        requiredBallPercentage = 0.9f;
    }

    private void Update()
    {
        if (startBalls[startBalls.Length - 1].startProcessCompleted && !gameSetted)
        {
            foreach (Balls ball in startBalls)
            {
                ball.TransitionToState(ball.activeState);
            }
            gameSetted = true;
        }

        if (finishEvents.completedBallCount == 0)
            return;
        if (!levelCompleted && !levelFailed)
        {
            completePercentage = Mathf.Abs((finishEvents.completedBallCount * 100) / activeBalls.Count);
            completePercentageText.text = "%" + completePercentage.ToString();
            startTimer = true;
        }

        if (finishEvents.completedBallCount >= activeBalls.Count * requiredBallPercentage && !levelFailed)
        {
            levelCompleted = true;
            LevelCompleteEvents();
            startTimer = false;
        }
        if (startTimer && !levelCompleted && !levelFailed)
        {
            SetTime();
        }
    }

    void LevelCompleteEvents()
    {
        if (levelCompleted && !levelCompleteEvents)
        {
            Instantiate(fireWork, fireWork.transform.position, Quaternion.identity);
            blackBackground.SetActive(true);
            levelCompletedText.SetActive(true);
            tapToContinueButton.SetActive(true);
            levelCompleteEvents = true;
            

        }
    }

    void LevelFailedEvents()
    {
        if (levelFailed && !levelFailedEvents)
        {
            blackBackground.SetActive(true);
            levelFailedText.SetActive(true);
            tapToRestart.SetActive(true);
            levelFailedEvents = true;
            
        }
    }

    public void NextLevel()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex + 1);
    }

    public void RestartLevel()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void SetTime()
    {
        timer -= Time.deltaTime;
        second = (int)(timer % 60);
        splitSecond = (int)(timer * 60) % 60;
        timerText.text = string.Format("{00:00}:{1:00}", second, splitSecond);
        if (timer <= 0 && !levelCompleted)
        {
            timer = 0;
            levelFailed = true;
            startTimer = false;
            LevelFailedEvents();
        }
    }

    public void IntroStart()
    {

    }
}
