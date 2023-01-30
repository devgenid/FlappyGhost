using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static bool gameOver;
    void Awake() //Executes before Start
    {
        //pixels are 0,0 on left bottom and increase to up/right
        //unity units are 0,0 on the center of the screen
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0)); //pixels to unity units
    }

    private void Start() 
    {
        gameOver = false;
    }

    public void GameOver()
    {
        gameOver = true;
    }
}
