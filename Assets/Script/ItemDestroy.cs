using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject cat;
    private float objPosZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        objPosZ = this.gameObject.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera = GameObject.Find("Main Camera");
        if (mainCamera.transform.position.z >= objPosZ)
        {
            Destroy(gameObject);
        }
        cat = GameObject.Find("cat");
        if (cat.transform.position.z >= objPosZ)
        {
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
        }
    }
}
