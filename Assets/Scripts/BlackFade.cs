using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackFade : MonoBehaviour
{
   
    void OnBlackFadeFinished()
    {
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            SceneManager.LoadScene("Game");
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }

    }

}
