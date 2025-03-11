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
        //GetComponent<Collider2D>().enabled = true;
    }

    void DeactivateGlyph()
    {
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
        }

        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            if (isShown)
            {
                if (isBlu)
                {
                    if (bullet.isBlu)
                    {
                        DragonScript.sealIndex++;
                        Debug.Log("pisou!");
                        StopAllCoroutines();
                        Destroy(bullet.gameObject);
                    }
                    else
                    {
                        Debug.Log("errastes!");
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
