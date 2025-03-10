using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{
    bool moveUp;
    bool moveDown;

    public GameObject city;
    CityScript cs;
    //arma?

    private float rotationAroundSelfSpeed;

    public bool isDown = false;
    bool isCasting = false;
    bool isHowling = false;
    GameObject radar;
    GameObject howl;


    // Start is called before the first frame update
    void Start()
    {
        radar = transform.Find("Radar").gameObject;
        howl = transform.Find("Howl").gameObject;
        DeactivateRadar();
        DeactivateHowl();

    }

    // Update is called once per frame
    void Update()
    {

        moveUp = Input.GetKey(KeyCode.UpArrow);
        moveDown = Input.GetKey(KeyCode.DownArrow);


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

        if (Input.GetKeyDown(KeyCode.Z) && !isHowling)
        {
            StartCoroutine(StartHowling());
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

    void DeactivateHowl()
    {
        howl.SetActive(false);
    }

    IEnumerator ActivateRadar()
    {
        isCasting = true;
        radar.SetActive(true);
        yield return new WaitForSeconds(1.05f);
        DeactivateRadar();
        isCasting = false;
    }

    IEnumerator StartHowling()
    {
        isHowling = true;
        howl.SetActive(true);
        yield return new WaitForSeconds(1.05f);
        DeactivateHowl();
        isHowling = false;
    }




}
