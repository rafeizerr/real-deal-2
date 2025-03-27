using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreScript : MonoBehaviour
{
    public string color;
    public bool isTheOne;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HideCore()
    {
        if(isTheOne == false)
        {
        //mudar hue aqui
        //transformar em coroutine
        gameObject.SetActive(false);
        //Debug.Log("vou me esconder!");
        }
    }
    public void DisplayCore()
    {
        gameObject.SetActive(true);

    }
    
}
