using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        catObj = GameObject.Find("cat");
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
                GameObject textObjTrue = Instantiate(textPrefabTrue);
                textObjTrue.transform.position = new Vector3(tmpPosX, 0, tmpPosZ);
                textObjTrue.GetComponent<TextMesh>().text = "猫";
                GameObject textObjFalse = Instantiate(textPrefabFalse);
                textObjFalse.transform.position = new Vector3(-tmpPosX, 0, tmpPosZ);
                textObjFalse.GetComponent<TextMesh>().text = "犬";
            }
        }
    }
}