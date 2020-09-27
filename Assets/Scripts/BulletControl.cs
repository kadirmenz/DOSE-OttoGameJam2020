using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    Rigidbody rbBullet;
    float speed = 5f;
    void Start()
    {
        rbBullet = GetComponent<Rigidbody>();
        rbBullet.velocity = new Vector3(speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character" || other.gameObject.tag == "EggTag")
        {
            GameHolder.isDie = true;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
