using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol : MonoBehaviour
{
    GameObject symbol;

    // Start is called before the first frame update
    void Start()
    {
        //this.spriteRenderer = GetComponent<SpriteRenderer>();
        symbol = transform.Find("carol").gameObject;
        HideSymbol();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplaySymbol()
    {
        symbol.SetActive(true);
    }

    public void HideSymbol()
    {
        symbol.SetActive(false);
    }


}
