using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealScript : MonoBehaviour
{
    GameObject glyph;
    bool isShown = false; 
    // Start is called before the first frame update
    void Start()
    {
        glyph = transform.Find("Glyph").gameObject;
        DeactivateGlyph();


    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator HideGlyph()
    {
        yield return new WaitForSeconds(0.5f);
        glyph.SetActive(false);
        isShown = false;
    }

    void DisplayGlyph()
    {
        glyph.SetActive(true);
        isShown = true;
    }

    void DeactivateGlyph()
    {
        glyph.SetActive(false);
        isShown = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Radar radar = collision.GetComponent<Radar>();
        if (radar != null)
        {
            DisplayGlyph();
        }

        if (collision.gameObject.name == "Howl")
        {
            if(isShown)
            {
                Debug.Log("vamos jogar o jogo do contente!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Radar radar = collision.GetComponent<Radar>();
        if (radar != null)
        {
            StartCoroutine(HideGlyph());
        }
    }
}
