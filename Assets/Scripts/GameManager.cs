using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; //Text Mesh Pro lib
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
    public static int gameScore;
    int drawScore;
    public TextMeshProUGUI scoreText;

    private VolumeControl volumeControl;

    private AudioSource audioSource;
    public AudioClip transition;

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
        drawScore = 0;
        volumeControl = GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<VolumeControl>(); //find the one and only music player (Object not Objects)
        volumeControl.SetVolume(0.8f);
        audioSource = GetComponent<AudioSource>();
    }

    public void GameOver()
    {
        gameOver = true;
        Invoke("GameOverCanvasActivate",1f);
        score.SetActive(false);
        pauseBtn.SetActive(false);
        gameScore = score.GetComponent<ScoreControl>().GetScore(); //From the game object, get the script ScoreControl, and get the funtion from there
        volumeControl.SetVolume(0.8f);

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
        volumeControl.SetVolume(0.15f);
        PlaySound(transition);
        volumeControl.SetVolume(0.8f);

    }

    public void GameHasStarted()
    {
        gameHasStarted = true;
        score.SetActive(true);
        getReadyImg.SetActive(false);
        pauseBtn.SetActive(true);
        volumeControl.SetVolume(0.15f);

    }

    void GameOverCanvasActivate()
    {
        gameOverPanel.SetActive(true);
    }

    public void DrawScore()
    {
        if(drawScore <= gameScore)
        {
            scoreText.text = drawScore.ToString();
            drawScore ++;
            Invoke("DrawScore",0.1f);

        }
    }

    public void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
}
