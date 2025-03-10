using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{
    bool moveUp;
    bool moveDown;
    bool shoot;

    public GameObject city;
    CityScript cs;
    //arma?
    Gun[] guns;

    private float rotationAroundSelfSpeed;

    public bool isDown = false;
    bool isCasting = false;

    GameObject radar;



    // Start is called before the first frame update
    void Start()
    {
        radar = transform.Find("Radar").gameObject;

        DeactivateRadar();


        guns = transform.GetComponentsInChildren<Gun>();
        foreach (Gun gun in guns)
        {
            gun.isActive = true;
            /*
            //desativa guns com power up level requirement diferente de zero
            if (gun.powerUpLevelRequirement != 0)
            {
                gun.gameObject.SetActive(false);
            }
            */
        }

    }

    // Update is called once per frame
    void Update()
    {

        moveUp = Input.GetKey(KeyCode.UpArrow);
        moveDown = Input.GetKey(KeyCode.DownArrow);
        shoot = Input.GetKeyDown(KeyCode.Z);


        if (moveUp)
        {
            cs = city.GetComponent<CityScript>();
            cs.RotateUp();
            if (isDown)
            {
                MoveUp();
            }
        }

        if (moveDown)
        {
            cs = city.GetComponent<CityScript>();
            cs.RotateDown();
            MoveDown();
        }

        if (Input.GetKeyDown(KeyCode.X) && !isCasting)
        {
            StartCoroutine(ActivateRadar());
        }

        if (shoot)
        {
            shoot = false;
            foreach (Gun gun in guns)
            {
                if (gun.gameObject.activeSelf)
                {
                    gun.Shoot();
                }
            }
        }

    }


    void MoveDown()
    {
        isDown = true;
        transform.eulerAngles = new Vector3(0, 0, -180);
    }

    void MoveUp()
    {
        isDown = false;
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    void StopSpeed()
    {
        rotationAroundSelfSpeed = 0f;
    }

    void DeactivateRadar()
    {
        radar.SetActive(false);
    }



    IEnumerator ActivateRadar()
    {
        isCasting = true;
        radar.SetActive(true);
        yield return new WaitForSeconds(1.05f);
        DeactivateRadar();
        isCasting = false;
    }




}
