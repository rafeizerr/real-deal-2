using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturePoint : MonoBehaviour
{
    public int howMany;
    CircleCollider2D collider;

    //Core[] cores;


    void Start()
    {

        collider = GetComponent<CircleCollider2D>();
        collider.isTrigger = false;
        StartCoroutine(Spawn());

    }

    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D col)
    {
        howMany++;
        Capture();
        //Debug.Log("topogigio!");

    }

    public void Capture()
    {
        if (howMany == 2 || howMany == 3)
        {
            howMany = 0;
            GameObject[] cores = GameObject.FindGameObjectsWithTag("Core");
            if (cores != null)
            {
                foreach (GameObject core in cores)
                {
                    CoreScript coreScript = core.GetComponent<CoreScript>();
                    if (coreScript != null)
                    {
                        if (LassoManager.hue == coreScript.color)
                        {
                            Debug.Log("Capture!");
                            coreScript.HideCore();
                            //(adicionar string -dentro da lista que irei criar- no primeiro espaco disponivel)
                            //Debug.Log("cor do lasso: " + LassoManager.hue + "cor do core: " + coreScript.color);
                            GameObject[] manager = GameObject.FindGameObjectsWithTag("Manager");
                            if (manager != null)
                            {
                                foreach (GameObject man in manager)
                                {
                                    ConstellationManager constellationManager = man.GetComponent<ConstellationManager>();
                                    if (constellationManager != null)
                                    {
                                        constellationManager.AddColor(coreScript.color);
                                        Debug.Log("caralho");
                                    }
                                    else
                                    {
                                        Debug.Log("maria joaquina");
                                    }
                                }
                            }
                            else
                            {
                                Debug.Log("valeria carrosel");
                            }
                        }
                        else
                        {
                            coreScript.isTheOne = false;
                            coreScript.HideCore();
                            //Debug.Log("cor do lasso: " + LassoManager.hue + "cor do core: " + coreScript.color);
                        }

                    }
                }

            }
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.05f);
        collider.isTrigger = true;
    }
}


