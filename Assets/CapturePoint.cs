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
        Debug.Log("topogigio!");

    }

    public void Capture()
    {
        if (howMany == 2 || howMany == 3)
        {
            howMany = 0;
            Debug.Log("Capture!");
            GameObject[] cores = GameObject.FindGameObjectsWithTag("Core");
            if(cores != null)
            {
                foreach(GameObject core in cores)
                {
                    CoreScript coreScript = core.GetComponent<CoreScript>(); 
                    if(coreScript != null)
                    {
                        coreScript.HideCore();
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


