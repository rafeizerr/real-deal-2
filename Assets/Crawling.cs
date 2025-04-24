using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawling : MonoBehaviour
{
    bool moveFront;
    bool moveBack;
    bool moveLeft;
    bool moveRight;
    public float moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveFront = Input.GetKey(KeyCode.UpArrow);
        moveBack = Input.GetKey(KeyCode.DownArrow);
        moveLeft = Input.GetKey(KeyCode.LeftArrow);
        moveRight = Input.GetKey(KeyCode.RightArrow);
        
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        float moveAmount = moveSpeed * Time.fixedDeltaTime;

        Vector3 move = Vector3.zero;

        if (moveFront)
        {
            move.z += moveAmount;
        }


        if (moveBack)
        {
            move.z -= moveAmount;
        }


        if (moveLeft)
        {
            move.x -= moveAmount;
            //isLeft = true;
            //transform.rotation = Quaternion.Euler(0, 180, 00);
        }


        if (moveRight)
        {
            move.x += moveAmount;
            //isLeft = false;
            //transform.rotation = Quaternion.Euler(0, 00, 00);
        }

        float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.z * move.z);
        if (moveMagnitude > moveAmount)
        {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;

        }


        pos += move;
        transform.position = pos;

    }
}
