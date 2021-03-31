using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int gameMode;
    public int tutorialState = 0;
    public bool gameStart = false;
    public bool tutorialFlg = false;
    public TextMeshPro startText;
    public GameObject tutorialPrefab;
    private GameObject sceneChanger;
    private GameObject tutorialObj;
    private TextMeshProUGUI gameModeText;
    private float countDown = 4f;
    private int seconds;
    private AudioSource audioSource;
    private AudioController audioController;
    private bool flg = false;    

    // Start is called before the first frame update
    private void Awake()
    {
        this.sceneChanger = GameObject.Find("SceneChanger");
        this.gameMode = this.sceneChanger.GetComponent<SceneChanger>().gameMode;
        this.gameModeText = GameObject.Find("GameModeText").GetComponent<TextMeshProUGUI>();
        switch (this.gameMode)
        {
            case 1:
                this.gameModeText.text = "き\nへ\nん";
                break;
            case 2:
                this.gameModeText.text = "さ\nん\nず\nい";
                break;
            case 99:
                this.tutorialFlg = true;
                this.tutorialObj = Instantiate(tutorialPrefab);
                GameObject.Find("Canvas").transform.Find("TutorialPanel").gameObject.SetActive(true);
                this.gameModeText.text = "き\nへ\nん";
                break;
        }
        this.audioSource = GameObject.Find("cat").GetComponent<AudioSource>();
        this.audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameStart == false && this.tutorialFlg == false)
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
    public void SceneChange()
    {
        SceneManager.LoadScene("TitleScene");
        Destroy(this.sceneChanger);
    }

    public void OnClick()
    {
        this.tutorialState++;
    }
}
