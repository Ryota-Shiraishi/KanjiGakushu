using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    private GameObject textPanel;
    private GameObject textBtn;
    private TextMeshProUGUI textObj;

    // Start is called before the first frame update
    private void Start()
    {
        this.textPanel = GameObject.Find("TextPanel");
        this.textBtn = GameObject.Find("TextBtn");
        this.textObj = GameObject.Find("TextObj").GetComponent<TextMeshProUGUI>();
    }

    public void SetText(string txt,bool panel,bool btn)
    {
        textPanel.SetActive(panel);
        textBtn.SetActive(btn);
        textObj.text = txt;
    }
}
