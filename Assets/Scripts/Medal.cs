using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //to work with Sprites

public class Medal : MonoBehaviour
{

    public Sprite normalMedal, bronzeMedal, silverMedal, goldMedal;
    Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        int score = GameManager.gameScore;

        if(score >= 0 && score < 5)
            img.sprite = normalMedal;
        else if(score >= 5 && score < 10)
            img.sprite = bronzeMedal;
        else if(score >= 10 && score < 15)
            img.sprite = silverMedal;
        else if(score >= 15)
            img.sprite = goldMedal;

    }

 
}
