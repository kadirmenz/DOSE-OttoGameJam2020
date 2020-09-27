using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallControl : MonoBehaviour
{
    float rotateSpeed=5f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}
