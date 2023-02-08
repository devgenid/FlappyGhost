using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{
    Image img;

    public Sprite playSprite, pauseSprite;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();

    }

    public void OnGamePaused()
    {
        if(GameManager.gameIsPaused)
        {
            img.sprite = pauseSprite;
            GameManager.gameIsPaused = false;
            Time.timeScale = 1; //Resume game in normal mode. value >0 <1 game is in slow mode. value >1 game is in fast mode.
        }
        else
        {
            img.sprite = playSprite;
            GameManager.gameIsPaused = true;
            Time.timeScale = 0; //Pause game
        }

    }
}
