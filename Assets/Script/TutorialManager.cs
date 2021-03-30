using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject fishPrefab;
    public int state = 0;
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

    // Start is called before the first frame update
    void Start()
    {
        this.cat = GameObject.Find("cat");
        this.catRigidbody = this.cat.GetComponent<Rigidbody>();
        this.catAnimator = this.cat.GetComponent<Animator>();
        this.catAnimator.SetFloat("Speed", 0);
        this.textPanel = GameObject.Find("TextPanel");
        this.textObj = GameObject.Find("TextObj").GetComponent<TextMeshProUGUI>();
        this.textBtn = GameObject.Find("TextBtn");
        this.arrow = GameObject.Find("GameMode").transform.Find("Arrow").gameObject;
        this.answerText = GameObject.Find("AnswerText").GetComponent<TextMeshProUGUI>();
        this.leftButton = GameObject.Find("LeftButton");
        this.rightButton = GameObject.Find("RightButton");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.OnClick();
        }

        switch (this.state)
        {
            case 0:
                this.leftButton.SetActive(false);
                this.rightButton.SetActive(false);
                this.textObj.text = "おなかが すいたにゃあ";
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
                        this.fishObjTrue.name = "0_true";
                        this.fishObjTrue.tag = "True";
                        this.fishObjTrue.transform.position = new Vector3(-3f, 1.5f, 15f);
                    }
                    if (fishObjFalse is null)
                    { 
                        this.fishObjFalse = Instantiate(fishPrefab);
                        this.fishObjFalse.transform.Find("TmpPrefab").GetComponent<TextMeshPro>().text = "也";
                        this.fishObjFalse.transform.position = new Vector3(3f, 1.5f, 15f);
                    }
                    this.textPanel.SetActive(true);
                    this.textObj.text = "わあ！\nおいしそうな さかなだ！";
                }
                break;
            case 2:
                this.textObj.text = "どっちの さかなに しようか にゃあ？";
                break;
            case 3:
                this.textObj.text = "ねこちゃんが たべられる さかなには\nきまりが あるんだ";
                break;
            case 4:
                this.textObj.text = "いまは「きへん」を えらんでいるね";
                break;
            case 5:
                this.textObj.text = "";
                this.arrow.SetActive(true);
                break;
            case 6:
                this.arrow.SetActive(false);
                this.textObj.text = "「きへん」と くっつく かんじは\nどっちかな？";
                break;
            case 7:
                this.textObj.text = "「きへん」と くっつくのは\n「寸」だね";
                break;
            case 8:
                this.textObj.text = "「木」＋「寸」は どんな じ かな？";
                break;
            case 9:
                this.answerText.text = "村";
                this.textObj.text = "そう「村」だね";
                break;
            case 10:
                this.textObj.text = "さんかくを タップすると\nねこちゃんが よこに うごくよ";
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
                        this.answerText.text = "村";
                        this.catAnimator.SetFloat("Speed", 0);
                        this.catRigidbody.velocity = new Vector3(0f, 0f, 0f);
                        this.textPanel.SetActive(true);
                        this.textObj.text = "ありがとう！\nもっと たべたい にゃあ";
                    }
                }
                break;
            case 11:
                this.textObj.text = "ぼくと おいしい さかなを\nさがしにいこう";
                break;

                //そのままゲームをスタート
                //練習はばっちりだね
        }
    }

    public void OnClick()
    {
        this.state++;
    }
}
