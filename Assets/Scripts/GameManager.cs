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
    public GameObject pauseBtn;
    public Animator blackFadeAnim;

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
        pauseBtn.SetActive(false);

    }

    public void OnOkBtnPressed()
    {
        //blackFadeAnim.SetTrigger("FadeIn"); ->after changes this will cause the menu to load, needs changes to work
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //sceneBuildIndex found in build settings
        //after changes if commented, it will be executed as an event after Animation
    }

    public void OnMenuBtnPressed()
    {
        blackFadeAnim.SetTrigger("FadeIn");

    }

    public void GameHasStarted()
    {
        gameHasStarted = true;
        score.SetActive(true);
        getReadyImg.SetActive(false);
        pauseBtn.SetActive(true);
    }
}
