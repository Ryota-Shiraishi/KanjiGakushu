using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int gameMode;
    public bool gameStart = false;
    public TextMeshPro startText;
    public float countDown = 3f;
    int seconds;

    // Start is called before the first frame update
    private void Start()
    {
        this.gameMode = GameObject.Find("SceneChanger").GetComponent<SceneChanger>().gameMode;
        Debug.Log(gameMode);
    }

    // Update is called once per frame
    void Update()
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
