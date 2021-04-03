using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    private GameObject cat;
    private float difference;
    private float count = 1f;
    private TextMeshProUGUI answerText;

    // Start is called before the first frame update
    void Start()
    {
        this.cat = GameObject.Find("cat");
        this.difference = this.transform.position.z - cat.transform.position.z;
        answerText = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
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
