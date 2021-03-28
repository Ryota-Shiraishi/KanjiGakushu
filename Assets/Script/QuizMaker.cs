using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizMaker : MonoBehaviour
{
    public string[,] textData2D;
    public List<int> trueList = new List<int>();
    public List<int> falseList = new List<int>();
    public List<string> AnswerList = new List<string>();
    private GameManager gameManager;
    private int bushu;
    // Start is called before the first frame update
    void Start()
    {
        //GameManagerのスクリプトを取得する
        this.gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //CSVを開く
        TextAsset textasset = Resources.Load("kanji", typeof(TextAsset)) as TextAsset;
        string textData = textasset.text;
        //1次元配列に格納する
        string[] textArr = textData.Split('\n');
        //2次元配列に格納する
        int rowLength = textArr.Length;
        int colLength = textArr[0].Split(',').Length;
        this.textData2D = new string[rowLength, colLength];
        for (int r = 0; r < rowLength; r++)
        {
            string[] tmpArr = textArr[r].Split(',');
            for (int c = 0; c < colLength; c++)
            {
                this.textData2D[r, c] = tmpArr[c];
            }
        }
        if (this.gameManager.gameMode == 99)
        {
            this.bushu = 1;
        }
        else
        {
            this.bushu = this.gameManager.gameMode;
        }
        this.creList();
    }

    public void creList()
    { 
        List<int> trueList_wk = new List<int>();
        List<int> falseList_wk = new List<int>();
        int cnt;
        int rnd;

        for (int r = 1; r<textData2D.GetLength(0); r++)
        {
            if (textData2D[r, this.bushu] == "×")
            {
                falseList_wk.Add(r);
            }
            else
            {
                trueList_wk.Add(r);
            }
        }
        while (falseList_wk.Count > 0)
        {
            cnt = falseList_wk.Count;
            rnd = Random.Range(0, cnt);
            this.falseList.Add(falseList_wk[rnd]);
            falseList_wk.RemoveAt(rnd);
        }
        while (trueList_wk.Count > 0)
        {
            cnt = trueList_wk.Count;
            rnd = Random.Range(0, cnt);
            this.trueList.Add(trueList_wk[rnd]);
            trueList_wk.RemoveAt(rnd);
        }
    }

    public string exChar(bool exType)
    {
        int r = 0;
        switch (exType)
        {
            case true:
                r = this.trueList[0];
                this.trueList.RemoveAt(0);
                this.AnswerList.Add(this.textData2D[r, this.bushu]);
                break;
            case false:
                r = this.falseList[0];
                this.falseList.RemoveAt(0);
                break;
        }
        string tmpChar = this.textData2D[r, 0];
        return tmpChar;
    }
}
