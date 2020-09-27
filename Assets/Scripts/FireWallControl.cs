using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWallControl : MonoBehaviour
{
    [SerializeField] Transform instantiatePoint;
    [SerializeField] GameObject bullet;
    //[SerializeField] float fireRate = 3f;
    float createTime = 1.5f;
    float timer = 2f;

    // Update is called once per frame
    void Update()
    {
        Fire();
    }
    public void Fire()
    {
        timer += Time.deltaTime;
        if (timer >= createTime)
        {
            timer = 0f;
            Instantiate(bullet, instantiatePoint.position, Quaternion.Euler(0, 90, 90));
        }
        
    }
    
}
