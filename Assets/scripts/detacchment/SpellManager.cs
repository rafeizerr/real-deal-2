using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellManager : MonoBehaviour
{

    GameObject sigil1;
    GameObject sigil2;
    GameObject sigil3;

    GameObject wraith;

    public GameObject parabens;

    bool firstCast;
    bool secondCast;
    bool thirdCast;

    public bool isRed = false;
    public bool isYel = false;
    public bool isBlu = false;
    bool cutscene = false;

    public static float spellTimer = 0;
    int spellLimit = 10;

    public static float spellPoints = 0;

    bool isCasting = false;

    public Image armImage;
    public GameObject arm;
    [SerializeField] private Sprite[] braco;
    public int index;

    bool isExpelling = false;




    


    // Start is called before the first frame update
    void Start()
    {
        parabens.gameObject.SetActive(false);
        DeactivateArm();
        sigil1 = transform.Find("sigil1").gameObject;
        sigil2 = transform.Find("sigil2").gameObject;
        sigil3 = transform.Find("sigil3").gameObject;
        wraith = transform.Find("wraith").gameObject;
        DeactivateSigils();
        DeactivateWraith();
    }

    // Update is called once per frame
    void Update()
    {
     firstCast = Input.GetKeyDown(KeyCode.Q);
     secondCast = Input.GetKeyDown(KeyCode.W);
     thirdCast = Input.GetKeyDown(KeyCode.E);

     if(firstCast && !cutscene)
     {
        StartCoroutine(CastSpell1());
        if (!isRed && !isYel && !isBlu)
        {
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
       if(secondCast && !cutscene)
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
       if(thirdCast && !cutscene)
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

     if (isCasting == false && firstCast || secondCast || thirdCast && !cutscene)
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

     if (spellPoints == 100)
     {
        Expell();
     }

     if(Input.GetKeyDown(KeyCode.Z) && isExpelling)
     {
        Pierce();
        if (isCasting)
        {
            Debug.Log("voce venceu!");
            StartCoroutine(GameOver());
        }
     }


     
     
        
        

        
    }

    void DeactivateSigils()
    {
        sigil1.gameObject.SetActive(false);
        sigil2.gameObject.SetActive(false);
        sigil3.gameObject.SetActive(false);
    }

    void DeactivateWraith()
    {
        wraith.gameObject.SetActive(false);
    }

    void DeactivateArm()
    {
        arm.gameObject.SetActive(false);
    }

    void ResetSpell()
    {
        spellTimer = 0;
        isCasting = false;
        spellPoints = 0;
        isYel = isBlu = isRed = false;
        isExpelling = false; 
        DeactivateWraith();
        DeactivateArm();
    }

    void Expell()
    {
        wraith.gameObject.SetActive(true);
        arm.gameObject.SetActive(true);
        isExpelling = true;    
    }

    void Pierce()
    {
        armImage.sprite = braco[index];
        index ++;
        DeactivateWraith();
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

    IEnumerator GameOver()
    {
        cutscene = true;
        parabens.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        parabens.gameObject.SetActive(false);
        cutscene = false;
        


    }
}
