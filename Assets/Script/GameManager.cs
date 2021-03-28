using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int gameMode;
    public bool gameStart = false;
    public bool tutorialFlg = false;
    public TextMeshPro startText;
    private float countDown = 4f;
    private int seconds;
    private AudioSource audioSource;
    private AudioController audioController;
    private bool flg = false;

    // Start is called before the first frame update
    private void Awake()
    {
        this.gameMode = GameObject.Find("SceneChanger").GetComponent<SceneChanger>().gameMode;
        if (this.gameMode == 99)
        {
            this.tutorialFlg = true;
        }
        this.audioSource = GameObject.Find("cat").GetComponent<AudioSource>();
        this.audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart == false)
        {
            countDown -= Time.deltaTime;
            seconds = (int)countDown;
            switch (seconds)
            {
                case 0:
                    startText.text = "";
                    gameStart = true;
                    if (flg == true)
                    {
                        audioSource.PlayOneShot(this.audioController.countDown0);
                    }
                    break;
                case 1:
                    startText.text = "1";
                    if (flg == false)
                    {
                        audioSource.PlayOneShot(this.audioController.countDown1);
                        flg = true;
                    }
                    break;
                case 2:
                    startText.text = "2";
                    if (flg == true)
                    {
                        audioSource.PlayOneShot(this.audioController.countDown2);
                        flg = false;
                    }
                    break;
                case 3:
                    startText.text = "3";
                    if (flg == false)
                    {
                        audioSource.PlayOneShot(this.audioController.countDown3);
                        flg = true;
                    }
                    break;
            }
        }
    }
}
