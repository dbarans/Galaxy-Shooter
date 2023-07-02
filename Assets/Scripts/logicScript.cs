using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logicScript : MonoBehaviour
{

    public Text scoreText;
    private int score = 0;
    public GameObject hearts;
    public GameObject gameOverScreen;
    public GameObject startScreen;
    public GameObject pauseScreen;
    private bool pause = false;
    private bool gameIsOver = false;
    private bool gameStart = true;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0;
        startScreen.SetActive(true);
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        keyManager();
    }
    public void pauseGame()
    {
        if (!gameIsOver)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
            pause = true;
        }

    }
    public void resumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        pause = false;
        startScreen.SetActive(false);
    }
    public void startGame()
    {
        Time.timeScale = 1;
        startScreen.SetActive(false);
        gameStart = false;
    }
    public void restartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        resumeGame();

    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void addScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
        scoreText.text = score.ToString();
    }

    public void changeHealth(int health)
    {

        for (int i = 0; i < 5; i++)
        {
            Transform child = hearts.transform.GetChild(i);
            child.GetComponent<Image>().enabled = false;
        }
        for (int i = 0; i < health; i++)
        {
            Transform child = hearts.transform.GetChild(i);
            child.GetComponent<Image>().enabled = true;
        }

    }
    public void gameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
        gameIsOver = true;
    }
    void keyManager()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameStart)
            {
                if (pause)
                {
                    resumeGame();
                }
                else
                {
                    pauseGame();
                }
            }
            

        }
    }

}
