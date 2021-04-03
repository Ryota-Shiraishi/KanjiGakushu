﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject fishPrefab;
    private GameObject cat;
    private GameObject textPanel;
    private GameObject arrow;
    private GameObject textBtn;
    private GameObject leftButton;
    private GameObject rightButton;
    private GameObject fishObjTrue;
    private GameObject fishObjFalse;
    private TextMeshProUGUI textObj;
    private TextMeshProUGUI answerText;
    private Rigidbody catRigidbody;
    private Animator catAnimator;
    private CatController catController;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        this.cat = GameObject.Find("cat");
        this.catRigidbody = this.cat.GetComponent<Rigidbody>();
        this.catAnimator = this.cat.GetComponent<Animator>();
        this.catAnimator.SetFloat("Speed", 0);
        this.catController = this.cat.GetComponent<CatController>();
        this.textPanel = GameObject.Find("TextPanel");
        this.textObj = GameObject.Find("TextObj").GetComponent<TextMeshProUGUI>();
        this.textBtn = GameObject.Find("TextBtn");
        this.arrow = GameObject.Find("GameMode").transform.Find("Arrow").gameObject;
        this.answerText = GameObject.Find("AnswerText").GetComponent<TextMeshProUGUI>();
        this.leftButton = GameObject.Find("LeftButton");
        this.rightButton = GameObject.Find("RightButton");
        this.gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (this.gameManager.tutorialState)
        {
            case 0:
                this.leftButton.SetActive(false);
                this.rightButton.SetActive(false);
                this.textObj.text = "おなかが すいた にゃあ";
                break;
            case 1:
                this.textPanel.SetActive(false);
                this.catAnimator.SetFloat("Speed", 1);
                this.catRigidbody.velocity = new Vector3(0f, 0f, 5f);
                if (this.cat.transform.position.z > 5f)
                {
                    this.catAnimator.SetFloat("Speed", 0);
                    this.catRigidbody.velocity = new Vector3(0f, 0f, 0f);
                    if (fishObjTrue is null)
                    {
                        this.fishObjTrue = Instantiate(fishPrefab);
                        this.fishObjTrue.transform.Find("TmpPrefab").GetComponent<TextMeshPro>().text = "寸";
                        this.fishObjTrue.name = "0_tutorial";
                        this.fishObjTrue.tag = "Tutorial";
                        this.fishObjTrue.transform.position = new Vector3(-3f, 1.5f, 15f);
                    }
                    if (fishObjFalse is null)
                    {
                        this.fishObjFalse = Instantiate(fishPrefab);
                        this.fishObjFalse.transform.Find("TmpPrefab").GetComponent<TextMeshPro>().text = "也";
                        this.fishObjFalse.transform.position = new Vector3(3f, 1.5f, 15f);
                    }
                    this.textPanel.SetActive(true);
                    this.textObj.text = "わあ！さかなだ！\nおいしそう！";
                }
                break;
            case 2:
                this.textObj.text = "どっちの さかなに\nしようか にゃあ？";
                break;
            case 3:
                this.textObj.text = "ネコちゃんが食べられる魚には\nルールがあるんだ";
                break;
            case 4:
                this.textObj.text = "今は「きへん」を 選んでいるね";
                break;
            case 5:
                this.textObj.text = "";
                this.arrow.SetActive(true);
                break;
            case 6:
                this.arrow.SetActive(false);
                this.textObj.text = "「きへん」とくっつく漢字は\nどっちかな？";
                break;
            case 7:
                this.textObj.text = "「きへん」とくっつくのは\n「寸」だね";
                break;
            case 8:
                this.textObj.text = "「木」と「寸」がくっつくと\nどんな漢字になるかな？";
                break;
            case 9:
                this.textObj.text = "そう「村」だね";
                break;
            case 10:
                this.textObj.text = "三角のボタンをタップすると\nネコちゃんが横に動くよ";
                this.textBtn.SetActive(false);
                this.leftButton.SetActive(true);
                this.rightButton.SetActive(true);
                if (this.cat.transform.position.x == -2f)
                {
                    this.textBtn.SetActive(true);
                    this.textPanel.SetActive(false);
                    this.leftButton.SetActive(false);
                    this.rightButton.SetActive(false);
                    this.catAnimator.SetFloat("Speed", 1);
                    this.catRigidbody.velocity = new Vector3(0f, 0f, 5f);
                    if (this.cat.transform.position.z > 17f)
                    {
                        this.catAnimator.SetFloat("Speed", 0);
                        this.catRigidbody.velocity = new Vector3(0f, 0f, 0f);
                        this.textPanel.SetActive(true);
                        this.textObj.text = "おいしい！\nもっと たべたい にゃあ";
                    }
                }
                break;
            case 11:
                this.textObj.text = "おいしい さかなを\nいっしょに さがそう";
                break;
            case 12:
                this.textPanel.SetActive(false);
                this.leftButton.SetActive(true);
                this.rightButton.SetActive(true);
                this.catAnimator.SetFloat("Speed", 1);
                this.catRigidbody.velocity = new Vector3(0f, 0f, 10f);
                break;
        }
        if (this.catController.goalFlg)
        {
            this.catAnimator.SetFloat("Speed", 0);
            this.catRigidbody.velocity = new Vector3(0f, 0f, 0f);
            this.textPanel.SetActive(true);
            this.textObj.text = "れんしゅうは\nばっちりだね";
            this.textBtn.SetActive(false);
        }
    }
}
