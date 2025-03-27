using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ConstellationManager : MonoBehaviour
{
    public string[] sequence = { "", "", "" };
    string[] red = { "Red", "Red", "Red" };
    string[] yel = { "Yellow", "Yellow", "Yellow" };
    string[] carolina = { "Blue", "Red", "Yellow" };

    public GameObject carol;
    //public List<string> sequence = new List<string>() { "", "", "" };
    //int index = 0;
    public static string hue;

    // Start is called before the first frame update
    void Start()
    {
        carol.SetActive(false);
        hue = LassoManager.hue;

    }

    // Update is called once per frame
    void Update()
    {
        //hue = LassoManager.hue;
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Valor de hue: " + hue);
            AddColor(hue);
        }
        */


        if (sequence.SequenceEqual(carolina))
        {
            Dragon.dragonTime = true;
            carol.SetActive(true);
            Debug.Log("carol apareça!");
        }

    }

    public void AddColor(string cor) //talvez chamar isso no capture? amanha ver isso com calma ok
    {
        /*
        if(index < sequence.Length)
        {
            sequence[index++] = cor;
        }
        */
        for (int i = 0; i < sequence.Length; i++)
        {
            if (sequence[i] == "")
            {
                sequence[i] = cor;
                Debug.Log("cirilo de carrossel");
                break;


            }

        }



    }
}
