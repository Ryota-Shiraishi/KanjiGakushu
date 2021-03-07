﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CatController : MonoBehaviour
{
    private Animator Animator;
    private Rigidbody Rigidbody;
    private float velocityZ = 5f;
    private float movingRange = 2f;
    private float targetPositionX = 2f;
    private float sumTime = 0f;
    private float limitTime = 1f;
    private float ratio = 0f;

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
        //catをZ方向に移動させる
        this.Rigidbody.velocity = new Vector3(0f, 0f, velocityZ);

        //catの現在地を取得する
        Vector3 startPosition = this.transform.position;
        //catの目的地を取得する
        if (Input.GetKeyDown(KeyCode.LeftArrow) && -this.movingRange < startPosition.x)
        {
            targetPositionX = -this.movingRange;
            sumTime = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && this.movingRange > startPosition.x)
        {
            targetPositionX = this.movingRange;
            sumTime = 0f;
        }
        Vector3 targetPosition = new Vector3(targetPositionX, 0, startPosition.z);

        //キーを押してからの経過時間を取得する
        sumTime += Time.deltaTime;
        if (sumTime < limitTime)
        {
            //経過時間の割合を取得する
            ratio = sumTime / limitTime;
            //catを目的地へ移動させる
            transform.position = Vector3.Lerp(startPosition, targetPosition, ratio);
        }
    }

    void OnTriggerEnter(Collider other)
    {

    }
}
