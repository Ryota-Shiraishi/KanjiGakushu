using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioClip audioClip01;
    public AudioClip audioClip02;
    public AudioClip audioClip03;
    public AudioClip audioClip04;
    public AudioClip audioClip05;
    public AudioClip audioClip06;
    public AudioClip countDown0;
    public AudioClip countDown1;
    public AudioClip countDown2;
    public AudioClip countDown3;

    public AudioClip SoundSelecter()
    {
        int rnd;
        rnd = Random.Range(0, 6);//0～5
        switch (rnd)
        {
            case 0:
                audioClip = audioClip01;
                break;
            case 1:
                audioClip = audioClip02;
                break;
            case 2:
                audioClip = audioClip03;
                break;
            case 3:
                audioClip = audioClip04;
                break;
            case 4:
                audioClip = audioClip05;
                break;
            case 5:
                audioClip = audioClip06;
                break;
        }
        return audioClip;
    }
}
