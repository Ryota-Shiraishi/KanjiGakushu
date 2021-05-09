using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject fishPrefab;
    private GameObject cat;
    private GameObject arrow;
    private GameObject fishObj;
    private Animator catAnimator;
    private CatController catController;
    private ControlPanel controlPanel;
    private TutorialText tutorialText;
    private ItemGenerator itemGenerator;
    private GameManager gameManager;
    private int currentState;
    private int oldState;

    // Start is called before the first frame update
    void Start()
    {
        this.cat = GameObject.Find("Cat");
        this.catAnimator = this.cat.GetComponent<Animator>();
        this.catAnimator.SetFloat("Speed", 0);
        this.catController = this.cat.GetComponent<CatController>();
        this.arrow = GameObject.Find("GameMode").transform.Find("Arrow").gameObject;
        this.controlPanel = this.GetComponent<ControlPanel>();
        this.tutorialText = this.GetComponent<TutorialText>();
        this.itemGenerator = GameObject.Find("ItemGenerator").GetComponent<ItemGenerator>();
        this.gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        this.currentState = this.oldState = this.gameManager.tutorialState;
    }

    // Update is called once per frame
    void Update()
    {
        //一度で完結する処理
        this.currentState = this.gameManager.tutorialState;
        if (this.currentState > this.oldState || this.currentState == 0)
        {
            this.oldState = currentState;
            switch (this.gameManager.tutorialState)
            {
                case 0:
                    this.controlPanel.SetActive(false);
                    this.tutorialText.SetText("おなかが すいた にゃあ", true, true);
                    break;
                case 1:
                    this.tutorialText.SetText("", false, false);
                    this.catAnimator.SetFloat("Speed", 1);
                    //一度では完結しない処理ブロックにも処理あり
                    break;
                case 2:
                    this.tutorialText.SetText("どっちの さかなに\nしようか にゃあ？", true, true);
                    break;
                case 3:
                    this.tutorialText.SetText("ネコちゃんが食べられる魚には\nルールがあるんだ", true, true);
                    break;
                case 4:
                    this.tutorialText.SetText("今は「きへん」を 選んでいるね", true, true);
                    break;
                case 5:
                    this.tutorialText.SetText("", true,true);
                    this.arrow.SetActive(true);
                    break;
                case 6:
                    this.tutorialText.SetText("「きへん」とくっつく漢字は\nどっちかな？", true, true);
                    this.arrow.SetActive(false);
                    break;
                case 7:
                    this.tutorialText.SetText("「きへん」とくっつくのは\n「寸」だね", true, true);
                    break;
                case 8:
                    this.tutorialText.SetText("「木」と「寸」がくっつくと\nどんな漢字になるかな？", true, true);
                    break;
                case 9:
                    this.tutorialText.SetText("そう「村」だね", true, true);
                    break;
                case 10:
                    this.tutorialText.SetText("三角のボタンをタップすると\nネコちゃんが横に動くよ", true, false);
                    this.controlPanel.SetActive(true);
                    //一度では完結しない処理ブロックにも処理あり
                    break;
                case 11:
                    this.tutorialText.SetText("おいしい さかなを\nいっしょに さがそう", true, true);
                    break;
                case 12:
                    this.tutorialText.SetText("", false, false);
                    this.controlPanel.SetActive(this);
                    this.catAnimator.SetFloat("Speed", 1);
                    //一度では完結しない処理ブロックにも処理あり
                    break;
            }
        }
        //一度では完結しない処理
        switch (this.currentState)
        {
            case 1:
                //移動後のチュートリアル
                if (this.cat.transform.position.z > 5f)
                {
                    if (this.fishObj is null)
                    {
                        this.itemGenerator.TutorialObj();
                        this.fishObj = GameObject.Find("0_tutorial");
                    }
                    if (this.catController.walkFlg == true)
                    {
                        this.catAnimator.SetFloat("Speed", 0);
                        this.tutorialText.SetText("わあ！さかなだ！\nおいしそう！", true, true);
                    }
                }
                break;
            case 10:
                //catがx座標-2に移動したときの処理
                if (this.cat.transform.position.x < -1f && this.cat.transform.position.z < 17f)
                {
                    if (this.catController.walkFlg == false)
                    {
                        this.tutorialText.SetText("", false, false);
                        this.controlPanel.SetActive(false);
                        this.catAnimator.SetFloat("Speed", 1);
                    }
                }
                if (this.cat.transform.position.z > 17f)
                {
                    if (this.catController.walkFlg == true)
                    {
                        this.catAnimator.SetFloat("Speed", 0);
                        this.tutorialText.SetText("おいしい！\nもっと たべたい にゃあ", true, true);
                    }
                }
                break;
            case 12:
                if (this.catController.goalFlg)
                {
                    this.tutorialText.SetText("れんしゅうは\nばっちりだね", true, false);
                }
                break;
        }
    }
}
