using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateManager : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;
    [SerializeField] GameObject TouchAudioGameObject;
    AudioSource TouchAudio;
    public void Update()
    {
        TouchAudio = TouchAudioGameObject.GetComponent<AudioSource>();
        if (Input.GetButtonDown("Fire1"))
            PutCube(Input.mousePosition);
    }

    public void PutCube(Vector2 mousePosition)
    {
        RaycastHit hit = RayFromCamera(mousePosition, 1000.0f);
        if (hit.transform.gameObject.tag != "WallTag" && hit.transform.gameObject.tag != "enemy" && hit.transform.gameObject.tag != "CubeTag"  &&
            hit.transform.gameObject.tag != "BottomTag" && hit.transform.gameObject.tag != "HatchingTag" && hit.transform.gameObject.tag != "EggTag")
        {
            TouchAudio.Play();
            GameObject.Instantiate(cubePrefab, hit.point, Quaternion.Euler(90,0,0));
            Debug.Log(hit.transform.gameObject.name);
        }
        
    }

    public RaycastHit RayFromCamera(Vector3 mousePosition, float rayLength)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Physics.Raycast(ray, out hit, rayLength);
        return hit;
    }
}
