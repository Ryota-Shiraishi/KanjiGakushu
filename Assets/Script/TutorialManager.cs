using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject fishPrefab;
    private int state = 0;
    private GameObject cat;
    private TextMeshProUGUI textObj;
    private Rigidbody catRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        this.cat = GameObject.Find("cat");
        this.catRigidbody = this.cat.GetComponent<Rigidbody>();
        this.textObj = GameObject.Find("TextObj").GetComponent<TextMeshProUGUI>();
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
                this.textObj.text = "おなかが すいたにゃあ";
                break;
            case 1:
                this.textObj.gameObject.SetActive(false);
                this.catRigidbody.velocity = new Vector3(0f, 0f, 5f);
                if(this.cat.transform.position.z > 5f)
                {
                    this.catRigidbody.velocity = new Vector3(0f, 0f, 0f);
                    GameObject fishObjTrue = Instantiate(fishPrefab);
                    fishObjTrue.transform.Find("TmpPrefab").GetComponent<TextMeshPro>().text = "寸";
                    fishObjTrue.transform.position = new Vector3(3f, 1.5f, 15f);
                    GameObject fishObjfalse = Instantiate(fishPrefab);
                    fishObjfalse.transform.Find("TmpPrefab").GetComponent<TextMeshPro>().text = "也";
                    fishObjfalse.transform.position = new Vector3(-3f, 1.5f, 15f);


                    //わあ！おいしそうなさかながあるよ！
                    //どっちのさかなにしようかにゃあ
                    //ナレ：ねこちゃんがたべられるさかなにはきまりがあるんだ
                    //ナレ：いまは木編モードだね。
                    //木編の絵を強調
                    //ナレ：木編とくっつく漢字はどっちかな？
                    //ナレ：木編とくっつくのは「寸」だね。
                    //ナレ：「木」＋「寸」はなにかな？
                    //「村」を表示
                    //三角をタップして、ねこちゃんにおさかなをたべさせよう
                    //うごかして、さかなをたべさせる
                    //さかなをたべる（おいしい）
                    //ねこ：ありがとう　もっといっぱいたべたいにゃあ
                    //ねこ：ぼくとおいしいさかなを探しにいこう
                    //そのままゲームをスタート
                    //練習はばっちりだね
                }
                break;
        }
    }

    public void OnClick()
    {
        this.state++;
    }
}
