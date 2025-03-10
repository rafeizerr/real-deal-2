using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotation : MonoBehaviour
{

    [SerializeField] private float rotationSpeed = 270f;
    [SerializeField] private float rotationAroundSelfSpeed = 180f;
    [SerializeField] private Transform rotateAround;


    // Update is called once per frame
    void Update()
    {
    this.transform.RotateAround(rotateAround.position, Vector3.forward, rotationSpeed * Time.deltaTime);  
    this.transform.Rotate(Vector3. forward, rotationAroundSelfSpeed * Time.deltaTime);    
    }
}

