using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonScript : MonoBehaviour
{
    bool moveUp;
    bool moveDown;
    bool shoot;

    bool aimUp;
    bool aimDown;

    public GameObject city;
    RotationScript rs;

    public GameObject rotGun;
    RotationScript rg;
    //arma?
    Gun[] guns;

    public static int sealIndex;


    private float rotationAroundSelfSpeed;

    public bool isDown = false;
    bool isCasting = false;

    GameObject radar;

    public static string color;
    public GameObject[] seals;
    public GameObject fail;

    public static bool hasFumbled;



    // Start is called before the first frame update
    void Start()
    {
        fail.SetActive(false);
        radar = transform.Find("Radar").gameObject;

        DeactivateRadar();
        color = "Blue";



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
        if (hasFumbled)
        {

            seals = GameObject.FindGameObjectsWithTag(color);
            if (seals != null)
            {
                
                foreach (GameObject seal in seals)
                {
                    SealScript sealScript = seal.GetComponent<SealScript>(); 
                    if (sealScript != null) 
                    {
                        sealScript.DeactivateGlyph(); 
                    }
                }
            }
        }

            moveUp = Input.GetKey(KeyCode.UpArrow);
            moveDown = Input.GetKey(KeyCode.DownArrow);
            shoot = Input.GetKeyDown(KeyCode.Z);
            aimUp = Input.GetKey(KeyCode.LeftArrow);
            aimDown = Input.GetKey(KeyCode.RightArrow);

            //isso e so um placeholder e teste de string e tags
            if (Input.GetKey(KeyCode.G))
            {
                seals = GameObject.FindGameObjectsWithTag(color);
                if (seals != null)
                    foreach (GameObject seal in seals)
                    {
                        seal.gameObject.SetActive(false);
                    }
            }


            if (moveUp)
            {
                rs = city.GetComponent<RotationScript>();
                rs.RotateUp();
                if (isDown)
                {
                    MoveUp();
                }
            }

            if (moveDown)
            {
                rs = city.GetComponent<RotationScript>();
                rs.RotateDown();
                if (!isDown)
                {
                    MoveDown();
                }
            }


            if (aimUp)
            {
                rg = rotGun.GetComponent<RotationScript>();
                rg.RotateUp();
            }

            if (aimDown)
            {
                rg = rotGun.GetComponent<RotationScript>();
                rg.RotateDown();
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
            Vector3 theScale = transform.localScale;
            theScale.y *= -1;
            transform.localScale = theScale;
        }

        void MoveUp()
        {
            isDown = false;
            Vector3 theScale = transform.localScale;
            theScale.y *= -1;
            transform.localScale = theScale;
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
