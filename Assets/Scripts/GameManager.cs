using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static bool gameOver;
    public static bool gameHasStarted;
    public static bool gameIsPaused;

    public GameObject gameOverPanel;
    public GameObject score;

    public GameObject getReadyImg;
    void Awake() //Executes before Start
    {
        //pixels are 0,0 on left bottom and increase to up/right
        //unity units are 0,0 on the center of the screen
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0)); //pixels to unity units
    }

    private void Start() 
    {
        gameOver = false;
        gameHasStarted = false;
        gameIsPaused = false;

    }

    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        score.SetActive(false);
    }

    public void OnOkBtnPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //sceneBuildIndex found in build settings
    }

    public void GameHasStarted()
    {
        gameHasStarted = true;
        score.SetActive(true);
        getReadyImg.SetActive(false);
    }
}
