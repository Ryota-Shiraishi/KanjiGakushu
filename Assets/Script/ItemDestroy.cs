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
        this.objPosZ = this.gameObject.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        this.mainCamera = GameObject.Find("Main Camera");
        if (this.mainCamera.transform.position.z >= objPosZ)
        {
            Destroy(gameObject);
        }
        this.cat = GameObject.Find("Cat");
        if (this.cat.transform.position.z >= objPosZ)
        {
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
        }
    }
}
