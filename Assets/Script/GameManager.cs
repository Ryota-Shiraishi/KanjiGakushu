using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int gameMode;
    public bool gameStart = false;
    public TextMeshPro startText;
    public float countDown = 4f;
    private int seconds;

    // Start is called before the first frame update
    private void Awake()
    {
        this.gameMode = GameObject.Find("SceneChanger").GetComponent<SceneChanger>().gameMode;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart == false)
        {
            countDown -= Time.deltaTime;
            seconds = (int)countDown;
            if (seconds > 0)
            {
                startText.text = seconds.ToString();
            }
            else
            {
                startText.text = "";
                gameStart = true;
            }
        }
    }
}
