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
    private int objNo = 0;
    private QuizMaker quizMaker;

    // Start is called before the first frame update
    void Start()
    {
        this.catObj = GameObject.Find("Cat");
        this.quizMaker = GameObject.Find("QuizMaker").GetComponent<QuizMaker>(); 
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
                if (this.objNo < 10)
                {
                    float tmpPosX;
                    if (Random.Range(1, 11) % 2 == 0)
                    {
                        tmpPosX = -3;
                    }
                    else
                    {
                        tmpPosX = 3;
                    }
                    //正解のオブジェクトを生成する
                    GameObject fishObjTrue = Instantiate(fishPrefab);
                    fishObjTrue.name = this.objNo.ToString() + "_true";
                    fishObjTrue.tag = "True";
                    fishObjTrue.transform.position = new Vector3(tmpPosX, 1.5f, tmpPosZ);
                    //オブジェクトに漢字を表示する
                    fishObjTrue.transform.Find("TmpPrefab").GetComponent<TextMeshPro>().text = this.quizMaker.exChar(true);
                    //不正解のオブジェクトを生成する
                    GameObject fishObjFalse = Instantiate(fishPrefab);
                    fishObjFalse.name = this.objNo.ToString() + "_false";
                    fishObjFalse.tag = "False";
                    fishObjFalse.transform.position = new Vector3(-tmpPosX, 1.5f, tmpPosZ);
                    //オブジェクトに漢字を表示する
                    fishObjFalse.transform.Find("TmpPrefab").GetComponent<TextMeshPro>().text = this.quizMaker.exChar(false);
                    this.objNo++;
                }
            }
        }
    }

    public void TutorialObj()
    {
        GameObject fishObjTrue = Instantiate(fishPrefab);
        fishObjTrue.transform.Find("TmpPrefab").GetComponent<TextMeshPro>().text = "寸";
        fishObjTrue.name = "0_tutorial";
        fishObjTrue.tag = "Tutorial";
        fishObjTrue.transform.position = new Vector3(-3f, 1.5f, 15f);
        GameObject fishObjFalse = Instantiate(fishPrefab);
        fishObjFalse.transform.Find("TmpPrefab").GetComponent<TextMeshPro>().text = "也";
        fishObjFalse.transform.position = new Vector3(3f, 1.5f, 15f);
    }
}