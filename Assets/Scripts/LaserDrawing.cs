using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDrawing : MonoBehaviour
{
    
    private LineRenderer lineRenderer;
    private float counter;
    private float dist;
    float maxDistance = 50f;
    [SerializeField] Transform origin;
    [SerializeField] Transform destination;
    
    
    float lineDrawSpeed=6f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetWidth(.45f, .45f);

        dist = Vector3.Distance(origin.position, destination.position);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 difference =  destination.position- origin.position;
        if (Physics.Raycast(origin.position, difference,out hit,10000))
        {

            if (hit.transform.gameObject.tag == "Character")
            {
                GameHolder.isDie = true;
            }
             lineRenderer.SetPosition(1, hit.point);
            
        }
        
        
    }
}
