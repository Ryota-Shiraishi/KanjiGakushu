using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    private Animator Animator;
    private Rigidbody Rigidbody;
    private float velocityZ = 15f;
    private float velocityX = 15f;
    private float movingRange = 2f;

    // Start is called before the first frame update
    void Start()
    {
        this.Animator = GetComponent<Animator>();
        this.Animator.SetFloat("Speed", 1);
        this.Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputVelocityX = 0;
        //float positionX = this.transform.position.x;

        if (Input.GetKey(KeyCode.LeftArrow) && -this.movingRange < this.transform.position.x)
        {
            inputVelocityX = -this.velocityX;
            //positionX = -2;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < this.movingRange)
        {
            inputVelocityX = this.velocityX;
            //positionX = 2;
        }
        this.Rigidbody.velocity = new Vector3(inputVelocityX, 0, velocityZ);
        //this.transform.position = new Vector3(positionX,this.transform.position.y,this.transform.position.z);
    }
}
