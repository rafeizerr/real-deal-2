using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            JogaBola();
        }
    }

    void JogaBola()
    {
        //velocity = direction * speed;
        //float step = moveSpeed * Time.deltaTime;

        // move sprite towards the target location
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

        m_Rigidbody.AddForce(transform.forward * m_Thrust);
        //Debug.Log("rato");
    }
}
