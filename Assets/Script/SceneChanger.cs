using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public int gameMode;
    public AudioClip kihen;
    public AudioClip sanzui;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void OnClick(int num)
    {
        this.gameMode = num;
        switch (this.gameMode)
        {
        case 1:
                this.gameObject.GetComponent<AudioSource>().PlayOneShot(this.kihen);
                break;
        case 2:
                this.gameObject.GetComponent<AudioSource>().PlayOneShot(this.sanzui);
                break;
        }
        Invoke(nameof(DelayMethod), 1f);
    }

    void DelayMethod()
    {
        SceneManager.LoadScene("GameScene");
    }
}
