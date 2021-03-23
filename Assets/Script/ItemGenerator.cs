using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class ItemGenerator : MonoBehaviour
{
    //FishPrefabを入れる
    public GameObject fishPrefab;
    //スタート地点
    private int startPos = 30;
    //ゴール地点
    private int goalPos = 360;
    //catを入れる
    private GameObject catObj;
    //catのZ座標を入れる
    private float catPosZ = 0f;
    private int tsukuri = 0;
    private int objNo = 0;
    QuizMaker quizMaker;

    // Start is called before the first frame update
    void Start()
    {
        this.catObj = GameObject.Find("cat");
        this.quizMaker = GameObject.Find("QuizMaker").GetComponent<QuizMaker>(); ;
        this.quizMaker.creList();
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
                this.objNo++;
                //正解のオブジェクトを生成する
                GameObject fishObjTrue = Instantiate(fishPrefab);
                fishObjTrue.name = "Q" + this.objNo.ToString() + "_true";
                fishObjTrue.tag = "True";
                fishObjTrue.transform.position = new Vector3(tmpPosX, 1.5f, tmpPosZ);
                //漢字を選ぶ
                int cnt = this.quizMaker.trueList.Count;
                if (cnt == 0)
                {
                    this.quizMaker.creList();
                    cnt = this.quizMaker.trueList.Count;
                }
                int rnd = Random.Range(0, cnt);
                int r = this.quizMaker.trueList[rnd];
                string tmpChar = this.quizMaker.exChar(r, this.tsukuri);
                this.quizMaker.trueList.RemoveAt(rnd);
                //オブジェクトに漢字を表示する
                fishObjTrue.transform.Find("TmpPrefab").GetComponent<TextMeshPro>().text = tmpChar;

                //不正解のオブジェクトを生成する
                GameObject fishObjFalse = Instantiate(fishPrefab);
                fishObjFalse.name = "Q" + this.objNo.ToString() + "_false";
                fishObjFalse.tag = "False";
                fishObjFalse.transform.position = new Vector3(-tmpPosX, 1.5f, tmpPosZ);
                //漢字を選ぶ
                rnd = Random.Range(0, this.quizMaker.falseList.Count);
                r = this.quizMaker.falseList[rnd];
                tmpChar = this.quizMaker.exChar(r, this.tsukuri);
                this.quizMaker.falseList.RemoveAt(rnd);
                //オブジェクトに漢字を表示する
                fishObjFalse.transform.Find("TmpPrefab").GetComponent<TextMeshPro>().text = tmpChar;
            }
        }
    }
}