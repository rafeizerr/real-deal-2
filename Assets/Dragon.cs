using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dragon : MonoBehaviour
{
    GameObject radar;
    bool isCasting = false;

    public GameObject lassoMan;

    public GameObject colorPicker;

    public GameObject city;
    RotMovement rm;

    public GameObject grim;
    Grimorio grimorio;


    bool moveUp;
    public static bool dragonTime = false;


    string[] colors = { "Red", "Blue", "Yellow" };
    string cor = "";
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        grimorio = grim.GetComponent<Grimorio>();
        HideGrimoire();
        radar = transform.Find("Radar").gameObject;
        lassoMan.SetActive(false);

        DeactivateRadar();

    }

    // Update is called once per frame
    void Update()
    {
        if (!dragonTime)
        {
            if (Input.GetKeyDown(KeyCode.X) && !isCasting)
            {
                StartCoroutine(ActivateRadar());
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                ShowGrimoire();
            }

            if (Input.GetKeyUp(KeyCode.I))
            {
                HideGrimoire();
            }

            moveUp = Input.GetKey(KeyCode.UpArrow);
        }

        if (moveUp)
        {
            rm = city.GetComponent<RotMovement>();
            rm.RotateUp();
        }

        if (isCasting)
        {
            lassoMan.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Q) && isCasting)
        {
            LassoManager.hue = "Blue";
            LassoScript.colorIndex += 0;
        }
        if (Input.GetKeyDown(KeyCode.W) && isCasting)
        {
            LassoManager.hue = "Red";
            LassoScript.colorIndex += 1;
        }
        if (Input.GetKeyDown(KeyCode.E) && isCasting)
        {
            LassoManager.hue = "Yellow";
            LassoScript.colorIndex += 2;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetColor();

            GameObject[] cores = GameObject.FindGameObjectsWithTag("Core");
            if (cores != null)
            {
                foreach (GameObject core in cores)
                {
                    CoreScript coreScript = core.GetComponent<CoreScript>();
                    if (coreScript != null)
                    {
                        if (cor != coreScript.color)
                        {
                            coreScript.HideCore();
                            //(adicionar string -dentro da lista que irei criar- no primeiro espaco disponivel)
                        }
                        else
                        {
                            coreScript.isTheOne = true;
                        }
                    }
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeColor();
        }

    }

    void DeactivateRadar()
    {
        radar.SetActive(false);
    }

    void ChangeColor()
    {

        colorPicker.transform.Rotate(0f, 0f, -120f, Space.Self);
        //cor = colors[index];
        index++;
        if (index >= colors.Length)
        {
            index = 0;
        }
        Debug.Log("a sua cor é" + colors[index] + "(" + index + ")");
    }

    void SetColor()
    {
        cor = colors[index];
    }

    void ShowGrimoire()
    {
        grimorio.Show();
    }

    void HideGrimoire()
    {
        grimorio.Hide();
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
