using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{

      public bool facingRight = true;
        [SerializeField] private float rotationAroundSelfSpeed = 180f;
        [SerializeField] private float rotationAroundSelfNegativeSpeed = -180f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void RotateUp()
    {
    this.transform.Rotate(Vector3. forward, rotationAroundSelfSpeed * Time.deltaTime);    
    }

    public void RotateDown()
    {
    //rotationAroundSelfSpeed = rotationAroundSelfSpeed * -1;
    this.transform.Rotate(Vector3. forward, rotationAroundSelfNegativeSpeed * Time.deltaTime);    
    }
}
