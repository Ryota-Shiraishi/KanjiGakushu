using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    private GameObject cat;
    private float difference;
    private float count = 1f;
    private TextMeshPro answerText;

    // Start is called before the first frame update
    void Start()
    {
        this.cat = GameObject.Find("cat");
        this.difference = this.transform.position.z - cat.transform.position.z;
        answerText = this.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(0, this.transform.position.y, this.cat.transform.position.z + difference);
        if (this.answerText.text == "")
        {
            count = 1f;
        }
        else
        {
            count -= Time.deltaTime;
            if (count <= 0)
            {
                this.answerText.text = "";
            }
        }
    }
}
