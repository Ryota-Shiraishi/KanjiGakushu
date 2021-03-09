using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    GameObject MainCamera;
    float objPosZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        objPosZ = gameObject.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        MainCamera = GameObject.Find("Main Camera");
        if (MainCamera.transform.position.z >= objPosZ)
        {
            Destroy(gameObject);
        }
    }
}
