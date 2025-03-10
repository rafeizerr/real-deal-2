using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpellPoints : MonoBehaviour
{
    TextMeshProUGUI points;

    // Start is called before the first frame update
    void Start()
    {

        points = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {

        //points.text = Manager.spellPoints.ToString();
        points.text = SorceryManager.spellPoints.ToString();


    }
}
