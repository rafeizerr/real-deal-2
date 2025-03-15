using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealScript : MonoBehaviour
{
    GameObject glyph;

    public bool isRed;
    public bool isBlu;
    public bool isYel;

    bool isShown = false;
    LineController[] lineControllers;


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
        yield return new WaitForSeconds(1);
        glyph.SetActive(false);
        isShown = false;
    }

    void DisplayGlyph()
    {
        glyph = transform.Find("Glyph").gameObject;
        glyph.SetActive(true);
        isShown = true;
        Debug.Log("INFERNO VAI");
        //GetComponent<Collider2D>().enabled = true;
    }

    public void DeactivateGlyph()
    {
        glyph = transform.Find("Glyph").gameObject;
        glyph.SetActive(false);
        isShown = false;
        //GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Radar radar = collision.GetComponent<Radar>();
        if (radar != null)
        {
            DisplayGlyph();
            Debug.Log("DisplayGlyph");
        }

        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            if (isShown)
            {
                lineControllers = transform.GetComponentsInChildren<LineController>();
                foreach (LineController lineController in lineControllers)
                    if (DragonScript.sealIndex != lineController.sealIndexReq)
                    {
                        //DragonScript.hasFumbled = true;
                    }

                if (isBlu)
                {
                    if (bullet.isBlu)
                    {
                        DragonScript.sealIndex++;
                        //Debug.Log("pisou!");
                        //GetComponent<Collider2D>().enabled = false;
                        StopAllCoroutines();
                        Destroy(bullet.gameObject);
                    }
                    else
                    {
                        DragonScript.hasFumbled = true;
                    }

                }
                if (isRed)
                {

                }
                if (isRed)
                {

                }
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
