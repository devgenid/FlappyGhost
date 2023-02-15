using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
