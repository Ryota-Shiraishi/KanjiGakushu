using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ItemGenerator : MonoBehaviour
{
    //TextPrefabを入れる
    public GameObject textPrefabTrue;
    public GameObject textPrefabFalse;
    //スタート地点
    private int startPos = 30;
    //ゴール地点
    private int goalPos = 360;
    //catを入れる
    private GameObject catObj;
    //catのZ座標を入れる
    private float catPosZ = 0f;
    private string[,] textData2D;
    private int tsukuri = 0;
    private int bushu = 1;
    private List<int> trueList = new List<int>();
    private List<int> falseList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        catObj = GameObject.Find("cat");
        //CSVを開く
        TextAsset textasset = new TextAsset();
        textasset = Resources.Load("kanji", typeof(TextAsset)) as TextAsset;
        string textData = textasset.text;
        string[] textArr = textData.Split('\n');
        int rowLength = textArr.Length;
        int colLength = textArr[0].Split(',').Length;
        this.textData2D = new string[rowLength,colLength];
        for (int r = 0; r < rowLength; r++)
        {
            string[] tmpArr = textArr[r].Split(',');
            for (int c = 0; c < colLength; c++)
            {
                this.textData2D[r, c] = tmpArr[c];
            }
        }
        this.ListAdd();
    }

    // Update is called once per frame
    void Update()
    {
        float tmpPosZ = catObj.transform.position.z;
        if (tmpPosZ - catPosZ > 15)
        {
            //catのx座標を更新する
            catPosZ = tmpPosZ;
            tmpPosZ += 30;
            //
            if (tmpPosZ >= startPos & tmpPosZ <= goalPos)
            {
                float tmpPosX;
                if (Random.Range(1,11)%2 == 0)
                {
                    tmpPosX = -3;
                }
                else
                {
                    tmpPosX = 3;
                }
                //正解のオブジェクトを生成する
                GameObject textObjTrue = Instantiate(textPrefabTrue);
                textObjTrue.transform.position = new Vector3(tmpPosX, 0, tmpPosZ);
                int cnt = this.trueList.Count;
                if (cnt == 0)
                {
                    this.ListAdd();
                    cnt = this.trueList.Count;
                }
                int i = Random.Range(0, cnt);
                int r = this.trueList[i];
                string tmpChar = this.textData2D[r, this.tsukuri];
                textObjTrue.GetComponent<TextMesh>().text = tmpChar;
                this.trueList.RemoveAt(i);

                //不正解のオブジェクトを生成する
                GameObject textObjFalse = Instantiate(textPrefabFalse);
                textObjFalse.transform.position = new Vector3(-tmpPosX, 0, tmpPosZ);
                i = Random.Range(0, this.falseList.Count);
                r = this.falseList[i];
                tmpChar = this.textData2D[r, this.tsukuri];
                textObjFalse.GetComponent<TextMesh>().text = tmpChar;
                this.falseList.RemoveAt(i);
            }
        }
    }

    void ListAdd()
    {
        for (int r = 1; r < this.textData2D.GetLength(0); r++)
        {
            if (this.textData2D[r, this.bushu] == "×")
            {
                this.falseList.Add(r);
            }
            else
            {
                this.trueList.Add(r);
            }
        }
    }
}