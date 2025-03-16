using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    GameObject radar;
    bool isCasting = false;

    // Start is called before the first frame update
    void Start()
    {
        radar = transform.Find("Radar").gameObject;

        DeactivateRadar();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !isCasting)
        {
            StartCoroutine(ActivateRadar());
        }

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
