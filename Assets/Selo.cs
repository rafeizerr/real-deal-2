using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selo : MonoBehaviour
{
    CoreScript[] cores;
    // Start is called before the first frame update
    void Start()
    {
        cores = transform.GetComponentsInChildren<CoreScript>();
        foreach (CoreScript core in cores)
            core.HideCore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Radar radar = collision.GetComponent<Radar>();
        if (radar != null)
        {
            Debug.Log("DisplayCore");
            foreach (CoreScript core in cores)
                core.DisplayCore();
        }
    }
}
