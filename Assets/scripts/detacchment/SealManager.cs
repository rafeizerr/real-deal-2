using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealManager : MonoBehaviour
{
    public int requirement;
    public int sealIndex;
    public int sealHP = 100;
    [SerializeField] private ParticleSystem damageParticles;
    private ParticleSystem damageParticlesInstance;

    //public GameObject sorcery;


    // Start is called before the first frame update
    void Start()
    {
        //SorceryManager sorceryManager = sorcery.GetComponentInParent<SorceryManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (sealHP <= 0)
        {
            //StartCoroutine(DestroySeal());
            /*
            SorceryManager sorceryManager = sorcery.GetComponentInParent<SorceryManager>();
            sorceryManager.DeactivateWand();
            sorceryManager.ResetSpell();
            SorceryManager.levelIndex++;
            */
            Teste();

        }


    }

    public void Display()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    void TakeDamage(int damage)
    {
        sealHP -= damage;
        damageParticlesInstance = Instantiate(damageParticles, transform.position, Quaternion.identity);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Wand wand = collision.GetComponent<Wand>();
        if (wand != null)
        {
            TakeDamage(wand.power);
            //Debug.Log("ratinho legal");
        }
    }

    /*
        IEnumerator DestroySeal()
        {
            //SorceryManager.levelIndex++;

            SorceryManager sorceryManager = sorcery.GetComponentInParent<SorceryManager>();
            sorceryManager.DeactivateWand();
            sorceryManager.ResetSpell();
            yield return new WaitForSeconds(0.1f);
            Destroy(gameObject);
            Debug.Log("mil veces, mil mil ve-");
        }
    */

    void Teste()
    {
        Destroy(gameObject);
        SorceryManager.destroyedSeal = true;
    }

}
