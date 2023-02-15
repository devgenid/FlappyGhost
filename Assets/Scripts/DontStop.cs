using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontStop : MonoBehaviour
{

    void Awake() //Before Start
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("MusicPlayer");

        if(musicObj.Length > 1) //we want only one MusicPlayer. On next time, a new music player is initiated. we will keep the first.
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject); //keep the object on next scene
    }
}
