using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CatController : MonoBehaviour
{
    private Animator Animator;
    //private Rigidbody Rigidbody;
    //private float velocityZ = 15f;
    //private float velocityX = 15f;
    private float movingRange = 2f;

    // Start is called before the first frame update
    void Start()
    {
        this.Animator = GetComponent<Animator>();
        this.Animator.SetFloat("Speed", 1);
        //this.Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //float inputVelocityX = 0;
        Vector3 startPosition = this.transform.position;
        float endPositionX = startPosition.x;

        if (Input.GetKey(KeyCode.LeftArrow) && -this.movingRange < this.transform.position.x)
        {
            //inputVelocityX = -this.velocityX;
            endPositionX = -2;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < this.movingRange)
        {
            //inputVelocityX = this.velocityX;
            endPositionX = 2;
        }
        //this.Rigidbody.velocity = new Vector3(inputVelocityX, 0, velocityZ);

        float endPositionZ = startPosition.z + 0.1f;
        Vector3 endPosition = new Vector3(endPositionX, 0, endPositionZ);

        //float sumTime = 0f;
        //float ratio = 0f;
        //while (ratio < 1.0f)
        for (float i = 0f; i <= 1f; i += 0.1f)
        {
            //経過時間
            //sumTime += Time.deltaTime;
            //時間の割合
            //ratio = sumTime / 1;
            // オブジェクトの移動
            //transform.position = Vector3.Lerp(startPosition, endPosition, ratio);
            transform.position = Vector3.Lerp(startPosition, endPosition, i);
        }
    }

    void OnTriggerEnter(Collider other)
    {

    }
}
