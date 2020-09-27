using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggControl : MonoBehaviour
{
    [SerializeField] GameObject InstantiateManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "HatchingTag")
        {
            InstantiateManager.gameObject.SetActive(false);
            GameHolder.isHatching = true;
            Destroy(other.transform.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "WallTag" || collision.gameObject.tag == "enemy")
        {
            GameHolder.isDie = true;
            GameHolder.playFailed = transform.position;
            Destroy(this.gameObject);
        }
    }
}
