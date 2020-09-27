using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject Egg;
    [SerializeField] GameObject Character;
    [SerializeField] Vector3 offset=new Vector3(0,2,-9);
    [SerializeField] float followSpeed = 6f;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        FollowBall();
    }

    private void FollowBall()
    {
        if (GameHolder.isCameraWatchEgg)
        {
            //DifBetweenBallAndCamera = Egg.transform.position- transform.position;
            transform.position = Vector3.Lerp(transform.position, Egg.transform.position + offset, followSpeed );
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, Character.transform.position + offset, followSpeed * Time.deltaTime);
        }
        
    }
}
