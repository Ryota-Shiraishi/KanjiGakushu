using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatController : MonoBehaviour
{
    private GameManager gameManager;
    private Animator Animator;
    private Rigidbody Rigidbody;
    private AudioSource audioSource;
    private AudioController audioController;
    private QuizMaker quizMaker;
    //private TextMeshProUGUI scoreText;
    private TextMeshProUGUI goalText;
    private TextMeshProUGUI answerText;
    private GameObject titleBtn;
    private bool gameStart = false;
    private bool tutorialFlg = false;
    private float velocityZ = 0f;
    private float movingRange = 2f;
    private float targetPositionX = 2f;
    private float sumTime = 0f;
    private float limitTime = 1f;
    private float ratio = 0f;
    private float count;
    private int score = 0;
    private bool[] firstCollision = new bool[10];
    private bool isLButtonDown = false;
    private bool isRButtonDown = false;
    public bool goalFlg = false;

    // Start is called before the first frame update
    void Start()
    {
        this.Animator = GetComponent<Animator>();
        this.Animator.SetFloat("Speed", 1);
        this.Rigidbody = GetComponent<Rigidbody>();
        this.audioSource = GetComponent<AudioSource>();
        this.audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
        this.quizMaker = GameObject.Find("QuizMaker").GetComponent<QuizMaker>();
        this.gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //this.scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        this.goalText = GameObject.Find("GoalText").GetComponent<TextMeshProUGUI>();
        this.titleBtn = GameObject.Find("DefultPanel").transform.Find("TitleButton").gameObject;
        this.answerText = GameObject.Find("AnswerText").GetComponent<TextMeshProUGUI>();
        this.tutorialFlg = this.gameManager.tutorialFlg;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameStart = this.gameManager.gameStart;
        if (this.gameStart && this.goalFlg == false && this.tutorialFlg == false)
        {
            velocityZ = 10f;
        }

        //catをZ方向に移動させる
        this.Rigidbody.velocity = new Vector3(0f, 0f, velocityZ);

        //catの現在地を取得する
        Vector3 startPosition = this.transform.position;
        //catの目的地を取得する
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || this.isLButtonDown) && -this.movingRange < startPosition.x)
        {
            targetPositionX = -this.movingRange;
            sumTime = 0f;
        }
        else if ((Input.GetKeyDown(KeyCode.RightArrow) || this.isRButtonDown) && this.movingRange > startPosition.x )
        {
            targetPositionX = this.movingRange;
            sumTime = 0f;
        }
        Vector3 targetPosition = new Vector3(targetPositionX, 0, startPosition.z);

        //キーを押してからの経過時間を取得する
        sumTime += Time.deltaTime;
        if (sumTime < limitTime)
        {
            //経過時間の割合を取得する
            ratio = sumTime / limitTime;
            //catを目的地へ移動させる
            this.transform.position = Vector3.Lerp(startPosition, targetPosition, ratio);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goal")
        {
            this.goalFlg = true;
            velocityZ = 0f;
            this.Animator.SetFloat("Speed", 0);
            if (this.tutorialFlg == false)
            {
                this.goalText.text = this.score.ToString() + "てん";
            }
            this.titleBtn.SetActive(true);
        }

        int objNo = 0;

        if (this.goalFlg == false)
        {
            objNo = int.Parse(other.name.Substring(0, 1));
        }
        
        if (this.firstCollision[objNo] == false)
        {
            this.firstCollision[objNo] = true;
            switch (other.tag)
            {
                case "True":
                    //GetComponent<ParticleSystem>().Play();
                    Destroy(other.transform.GetChild(0).gameObject);
                    audioSource.PlayOneShot(this.audioController.SoundSelecter());
                    this.score += 10;
                    //this.scoreText.text = "まんぷくど：" + this.score.ToString();
                    this.answerText.text = this.quizMaker.AnswerList[objNo];
                    break;
                case "False":
                    Destroy(other.gameObject);
                    break;
                case "Tutorial":
                    Destroy(other.transform.GetChild(0).gameObject);
                    audioSource.PlayOneShot(this.audioController.SoundSelecter());
                    this.answerText.text = "村";
                    this.firstCollision[objNo] = false;
                    break;
            }
        }
    }

    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }

    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }
}
