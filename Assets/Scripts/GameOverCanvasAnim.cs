using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCanvasAnim : MonoBehaviour
{
   public GameObject medal;
   public GameManager gameManager;

   void MedalActivate() //called from the Animator of GameOverPanel, there is an event at the end of the animation calling this
   {
        medal.SetActive(true);
        gameManager.DrawScore();

   }
}
