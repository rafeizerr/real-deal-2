using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    [SerializeField] private float rotationAroundSelfSpeed = 180f;
    [SerializeField] private float rotationAroundSelfNegativeSpeed = -180f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)); 
        {
            RotateDown();
        }
            if(Input.GetKey(KeyCode.S));
        {
            RotateUp();
        }

    }

    public void RotateUp()
    {
    this.transform.Rotate(Vector3. forward, rotationAroundSelfSpeed * Time.deltaTime);    
    Debug.Log("cachorro");
    }

    public void RotateDown()
    {
    //rotationAroundSelfSpeed = rotationAroundSelfSpeed * -1;
    this.transform.Rotate(Vector3. forward, rotationAroundSelfNegativeSpeed * Time.deltaTime);    
     Debug.Log("gato");
    }
}
