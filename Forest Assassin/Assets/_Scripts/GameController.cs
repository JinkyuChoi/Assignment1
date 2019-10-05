using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int _lives;

    [SerializeField]
    private int _scores;

    public Text livesLabel;
    public Text scoresLabel;

    public bool gameOver;
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

                //SceneManager.LoadScene("End");
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
        Lives = 5;
        Scores = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
