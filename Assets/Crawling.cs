using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crawling : MonoBehaviour
{
    bool moveFront;
    bool moveBack;
    bool moveLeft;
    bool moveRight;
    bool moveStop;
    bool strike;
    public bool onRange = false;
    bool close = false;
    public float moveSpeed = 200;

    bool hasSword = false;

    [SerializeField] private float rotationAroundSelfSpeed = 90;

    public Animator walkAnimation;
    public Animator swordAnimation;

    //Rigidbody m_Rigidbody;
    float m_Speed;

    GameObject espada;

    public GameObject caroline;

    public GameObject target;
    private Vector3 position;

     Rigidbody m_Rigidbody;


    void Start()
    {
        caroline.SetActive(false);
        espada = transform.Find("Espada").gameObject;
        DeactivateEspada();
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        m_Speed = 10.0f;
        walkAnimation.Play("Idle");
        position = gameObject.transform.position;


    }


    // Update is called once per frame
    void Update()
    {

        moveFront = Input.GetKey(KeyCode.UpArrow);
        moveStop = Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow);
        moveBack = Input.GetKey(KeyCode.DownArrow);
        moveLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        moveRight = Input.GetKeyDown(KeyCode.RightArrow);
        strike = Input.GetKeyDown(KeyCode.Z);

        if (moveLeft)
        {
            //move.x -= moveAmount;
            //isLeft = true;
            //transform.rotation = Quaternion.Euler(0, 180, 00);
            //moveLeft = false;
            transform.eulerAngles += new Vector3(0, -90, 0);
        }


        if (moveRight)
        {
            //move.x += moveAmount;
            //isLeft = false;
            //transform.rotation = Quaternion.Euler(0, 90, 00);
            //this.transform.Rotate(Vector3. right, rotationAroundSelfSpeed);  
            //moveRight = false;
            transform.eulerAngles += new Vector3(0, 90, 0);
        }

        if (moveFront)
        {
            walkAnimation.Play("Walk");
            m_Rigidbody.velocity = transform.forward * m_Speed;
        }

        if (moveBack)
        {
            walkAnimation.Play("Walk");
            m_Rigidbody.velocity = -transform.forward * m_Speed;
        }

        if (moveStop)
        {
            walkAnimation.Play("Idle");
        }

        if (onRange && Input.GetKey(KeyCode.X))
        {
            ActivateEspada();
        }

        if (strike && hasSword)
        {
            StartCoroutine(Atk());
        }

        if (Input.GetKey(KeyCode.C))
        {
            caroline.SetActive(false);
            Destroy(GameObject.FindWithTag("wall"));
        }










    }

    /*
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

            float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.z * move.z);
            if (moveMagnitude > moveAmount)
            {
                float ratio = moveAmount / moveMagnitude;
                move *= ratio;

            }


            pos += move;
            transform.position = pos;

        }
    */

    void DeactivateEspada()
    {
        espada.SetActive(false);
    }

    void ActivateEspada()
    {
        espada.SetActive(true);
        hasSword = true;
        espada.GetComponent<Collider>().enabled = false;
    }

    IEnumerator Atk()
    {
        swordAnimation.Play("espada_atk");
        yield return new WaitForSeconds(0.30f);
        espada.GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(1);
        swordAnimation.Play("espada_idle");
        espada.GetComponent<Collider>().enabled = false;

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Sword")
        {
            Debug.Log("linda espada...");
            onRange = true;

        }

        if (collision.gameObject.name == "Caroline")
        {
            caroline.SetActive(true);
            close = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Caroline")
        {
            caroline.SetActive(false);
        }
    }


}
