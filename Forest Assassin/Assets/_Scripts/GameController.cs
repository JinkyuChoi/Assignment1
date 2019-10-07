using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//2019-10-06 by Jinkyu Choi
public class GameController : MonoBehaviour
{
    //code from Tom Tsiliopoulos
    [Header("InGame Variables")]
    [SerializeField]
    private int _lives;

    [SerializeField]
    private int _scores;

    [Header("UI Variables")]
    public Text livesLabel;
    public Text scoresLabel;
    public GameObject startLabel;
    public GameObject startButton;
    public GameObject endLabel;
    public GameObject restartButton;

    [Header("Audio Variables")]
    public AudioSource bgm;
    public AudioSource step;
    public AudioSource enemyHit;
    public AudioSource obstacleHit;

    public int Lives
    {
        get
        {
            return _lives;
        }

        set
        {
            _lives = value;
            if (_lives < 1)
            {
                //If it dies, it goes to end scene
                SceneManager.LoadScene("End");
            }
            else
            {
                livesLabel.text = "LIVES: " + _lives.ToString();
            }

        }
    }

    public int Scores
    {
        get
        {
            return _scores;
        }

        set
        {
            _scores = value;
            scoresLabel.text = "SCORES: " + _scores.ToString();
        }
    }

    //code from Tom Tsiliopoulos
    void Start()
    {
        //This will controll each scene's UI and audio variable according to current scene
        switch(SceneManager.GetActiveScene().name)
        {
            case "Start":
                scoresLabel.enabled = false;
                livesLabel.enabled = false;
                endLabel.SetActive(false);
                restartButton.SetActive(false);
                step.Stop();
                bgm.Stop();
                break;
            case "Main":
                startLabel.SetActive(false);
                startButton.SetActive(false);
                endLabel.SetActive(false);
                restartButton.SetActive(false);
                step.Play();
                bgm.Play();
                break;
            case "End":
                scoresLabel.enabled = false;
                livesLabel.enabled = false;
                startLabel.SetActive(false);
                startButton.SetActive(false);
                step.Stop();
                bgm.Stop();
                break;
        }

        //This is to initialize Lives and Score at the start of the game
        Lives = 5;
        Scores = 0;
    }

    void Update()
    {
        
    }

    //code from Tom Tsiliopoulos
    //If start button is clicked, it will active Main scene
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Main");
    }

    //code from Tom Tsiliopoulos
    //If restart button is clicked, it will active Main scene
    public void OnRestartButtionClick()
    {
        SceneManager.LoadScene("Main");
    }
}
