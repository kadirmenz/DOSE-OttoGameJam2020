using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    Rigidbody rbCharacter;
    float force = 200f;
    [SerializeField] GameObject TouchAudioGameObject;
    AudioSource TouchAudio;
    void Start()
    {
        rbCharacter = GetComponent<Rigidbody>();
        TouchAudio = TouchAudioGameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    private void Movement()
    {
        if (!GameHolder.isDie)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                TouchAudio.Play();
                rbCharacter.AddForce(transform.up * force);
                rbCharacter.AddForce(transform.right * force);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                TouchAudio.Play();
                rbCharacter.AddForce(transform.up * force);
                rbCharacter.AddForce(transform.right * -force);
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FinishTag")
        {
            GameHolder.isLevelPassed = true;
            GameHolder.playPassed = transform.position;
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CubeTag" || collision.gameObject.tag == "WallTag" || collision.gameObject.tag == "enemy")
        {
            GameHolder.isDie = true;
            GameHolder.playFailed = transform.position;
            Destroy(this.gameObject);
        }
        
    }
}
