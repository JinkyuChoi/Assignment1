using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int _lives;

    [SerializeField]
    private int _score;

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
                //livesLabel.text = "Lives: " + _lives.ToString();
            }

        }
    }

    public int Scores
    {
        get
        {
            return _score;
        }

        set
        {
            _score = value;
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
