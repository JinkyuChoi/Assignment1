﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int _lives;

    [SerializeField]
    private int _scores;

    public Text livesLabel;
    public Text scoresLabel;

    public GameObject startLabel;
    public GameObject startButton;

    public GameObject endLabel;
    public GameObject restartButton;

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
    // Start is called before the first frame update
    void Start()
    {

        switch(SceneManager.GetActiveScene().name)
        {
            case "Start":
                scoresLabel.enabled = false;
                livesLabel.enabled = false;
                endLabel.SetActive(false);
                restartButton.SetActive(false);
                break;
            case "Main":
                startLabel.SetActive(false);
                startButton.SetActive(false);
                endLabel.SetActive(false);
                restartButton.SetActive(false);
                break;
            case "End":
                scoresLabel.enabled = false;
                livesLabel.enabled = false;
                startLabel.SetActive(false);
                startButton.SetActive(false);
                break;
        }

        Lives = 5;
        Scores = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnRestartButtionClick()
    {
        SceneManager.LoadScene("Main");
    }
}
