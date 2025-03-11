using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTeste : MonoBehaviour
{
    
    [SerializeField] private Transform[] points;
    [SerializeField] private LineController line;

    public static bool begin = false;

    private void Start()
    {
        line.SetUpLine(points);
    }
}
