using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barto : MonoBehaviour
{
    float moveSpeed = 5;
    float threshold1 = 2;
    public float movementTime;
    //public GameObject target;
    private Vector2 target;
    private Vector2 position;


    bool moveLeft;

  

    // Start is called before the first frame update
    void Start()
    {  
        target = new Vector2(0.0f, 0.0f);
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(movementTime >= threshold1)
        {
            moveSpeed *= 0.5f;
            movementTime = 0;
        } 

    }

        private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        Vector2 move = Vector2.zero;

        if ( Input.GetKey(KeyCode.D))
        {
            move.x += moveAmount;
            movementTime += Time.deltaTime;
        }

        
        float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);
        if (moveMagnitude > moveAmount)
        {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }

        pos += move;
        transform.position = pos;

    }

    public void ResetSpeed()
    {
     moveSpeed = 5;
     movementTime = 0;
    }
}
