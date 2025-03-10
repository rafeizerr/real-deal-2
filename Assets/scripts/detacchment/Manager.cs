using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    GameObject sigil1;
    GameObject sigil2;
    GameObject sigil3; 

    bool firstCast;
    bool secondCast;
    bool thirdCast;

    public bool detach; 

    public bool isRed = false;
    public bool isYel = false;
    public bool isBlu = false;

    public static float spellTimer = 0;
    int spellLimit = 10;

    public static float spellPoints = 0;

    bool isCasting = false;

    public GameObject bartolomeu;
    

    // Start is called before the first frame update
    void Start()
    {
        sigil1 = transform.Find("sigil1").gameObject;
        sigil2 = transform.Find("sigil2").gameObject;
        sigil3 = transform.Find("sigil3").gameObject;

        DeactivateSigils();
    }

    // Update is called once per frame
    void Update()
    {
     firstCast = Input.GetKeyDown(KeyCode.Q);
     secondCast = Input.GetKeyDown(KeyCode.W);
     thirdCast = Input.GetKeyDown(KeyCode.E);


     if(firstCast)
     {
        StartCoroutine(CastSpell1());
        if (!isRed && !isYel && !isBlu)
        {
            Debug.Log("feitico 1");
            spellPoints = 10;
        }
        if (isRed)
        {
            Debug.Log("arrasou");
        }
        if (isYel)
        {
            Debug.Log("desarrasou");
        }
        if (isBlu)
        {
            spellPoints *= 2;
        }
     }
       if(secondCast)
     {
        StartCoroutine(CastSpell2());
        if (isRed)
        {
            spellPoints *= 2.5f;
        }
        if (isYel)
        {
            Debug.Log("desarrasou");
        }
        if (isBlu)
        {
            Debug.Log("to com medo");
        }
     }
       if(thirdCast)
     {
        StartCoroutine(CastSpell3());
        if (isRed)
        {
            Debug.Log("arrasou");
        }
        if (isYel)
        {
            spellPoints *= 2;
        }
        if (isBlu)
        {
            Debug.Log("to com medo");
        }
     }

     if (isCasting == false && firstCast || secondCast || thirdCast)
     {
        isCasting = true;
        
     }
     if (isCasting)
     {
        spellTimer += Time.deltaTime;
        if(spellTimer >= spellLimit)
         {
         Debug.Log("fim");
         ResetSpell();
         }
        else
         {
         spellTimer += Time.deltaTime;
         }
     }

     if (spellPoints == 100 || spellPoints == 250 )
     {
        detach = Input.GetKeyDown(KeyCode.X);
     }

     if(detach)
     {
        Debug.Log("ploc");
        Barto barto = bartolomeu.GetComponentInParent<Barto>();
        barto.ResetSpeed();
        
     }
       
    }

    void DeactivateSigils()
    {
        sigil1.gameObject.SetActive(false);
        sigil2.gameObject.SetActive(false);
        sigil3.gameObject.SetActive(false);
    }


    void ResetSpell()
    {
        spellTimer = 0;
        isCasting = false;
        spellPoints = 0;
        isYel = isBlu = isRed = false;
    }


    IEnumerator CastSpell1()
    {
        sigil1.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        sigil1.gameObject.SetActive(false);
         isRed = true;
         isYel = false;
         isBlu = false;    
    }

    IEnumerator CastSpell2()
    {
        sigil2.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        sigil2.gameObject.SetActive(false);
         isRed = false;
         isYel = true;
         isBlu = false;     
    }

    IEnumerator CastSpell3()
    {
        sigil3.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        sigil3.gameObject.SetActive(false);
         isRed = false;
         isYel = false;
         isBlu = true; 
    }

}
