using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreControl : MonoBehaviour
{
    int score, highscore;
    TextMeshProUGUI scoreText;

    public TextMeshProUGUI panelScore,panelHighScore;
    
    public GameObject newImg;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = score.ToString();
       // panelScore.text = score.ToString(); -> will be done from DrawScore with FX

        highscore = PlayerPrefs.GetInt("highscore"); //get the value from local save
        panelHighScore.text = highscore.ToString();

    }

    public void Scored()
    {
        score ++;
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();

        if(score > highscore)
        {
            highscore = score;
            panelHighScore.text = highscore.ToString();
            PlayerPrefs.SetInt("highscore", highscore); //local save in registry on Win or in xml file in Android device
            newImg.SetActive(true);
        }
    }

    public int GetScore() //will be used from other classes
    {
        return score;
    }
}
