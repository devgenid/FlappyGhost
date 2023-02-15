using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //used for loading other scene

public class MenuManager : MonoBehaviour
{
    public Animator blackFadeAnim;

    public void OnPlayBtnPressed()
    {
        blackFadeAnim.SetTrigger("FadeIn");
        //SceneManager.LoadScene("Game"); //Name found in build settings
    }

    public void OnRateBtn() {
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=com.kpogames.flappyghost"); //com.company.game
#endif
    }
}
