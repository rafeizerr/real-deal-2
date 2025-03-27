using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weakpoint : MonoBehaviour
{
    float randomNumber;
    float changeTimer;
    float changeTime = 1;

    public int hits = 60;

    public GameObject reference;
    Symbol symbol;

    public GameObject[] bullets;


    // Start is called before the first frame update
    void Start()
    {
        symbol = reference.GetComponent<Symbol>();

    }

    // Update is called once per frame
    void Update()
    {
        if (changeTimer >= changeTime)
        {
            changeTimer = 0;
            ChangePosition();
        }
        else
        {
            changeTimer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            hits--;
            Destroy(bullet.gameObject);
            {
                if (hits <= 0)
                {
                    Reveal();
                }
            }
        }
    }


    void Reveal()
    {
        bullets = GameObject.FindGameObjectsWithTag("bullet");
        if (bullets != null)
        {
            foreach (GameObject bullet in bullets)
            {
                bullet.gameObject.SetActive(false);
            }
        }


        symbol.DisplaySymbol();
        Destroy(gameObject);
    }

    public void ChangePosition()
    {

        Vector2 pos = transform.position;
        //Quaternion rot = transform.rotation;
        randomNumber = Random.Range(1, 5);
        if (randomNumber == 1)
        {
            pos.y = 2.0f;
            pos.x = 0;
            //rot.z = -90;
            transform.rotation = Quaternion.Euler(0, 00, 00);
            Debug.Log("numero é" + randomNumber);
        }
        if (randomNumber == 2)
        {
            pos.y = -2.0f;
            pos.x = 0;
            //rot.z = 0;
            transform.rotation = Quaternion.Euler(0, 00, 180);
            Debug.Log("numero é" + randomNumber);
        }
        if (randomNumber == 3)
        {
            pos.x = -2.0f;
            pos.y = 0;
            //rot.y = 0;
            transform.rotation = Quaternion.Euler(0, 00, 90);
            Debug.Log("numero é" + randomNumber);
        }
        if (randomNumber == 4)
        {
            pos.x = 2.0f;
            pos.y = 0;
            //rot.y = 0;
            transform.rotation = Quaternion.Euler(0, 00, -90);
            Debug.Log("numero é" + randomNumber);
        }
        transform.position = pos;
        //transform.rotation = rot;

    }

}
