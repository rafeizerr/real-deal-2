using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lr;
    private Transform[] points;

    public int sealIndexReq;
    

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
    }


    
    

    public void SetUpLine(Transform[] points)
    {
        lr.positionCount = points.Length;
        this.points = points;
    }

    private void Update()
    {
        if(DragonScript.sealIndex == sealIndexReq)
        {
            lr.enabled = true;
        }


        for (int i = 0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i].position);
        }
    }
    
}
