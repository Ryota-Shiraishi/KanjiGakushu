using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    private GameObject leftButton;
    private GameObject rightButton;

    // Start is called before the first frame update
    void Start()
    {
        this.leftButton = GameObject.Find("LeftButton");
        this.rightButton = GameObject.Find("RightButton");
    }

    public void SetActive(bool tmp)
    {
        this.leftButton.SetActive(tmp);
        this.rightButton.SetActive(tmp);
    }
}
