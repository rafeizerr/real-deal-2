using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detatch : MonoBehaviour
{
    public GameObject sorcery;
    public float spellPointRequirement;
    public int layerIndex;
    public GameObject bartolomeu;

    // Start is called before the first frame update
    void Start()
    {
        SorceryManager sorceryManager = sorcery.GetComponentInParent<SorceryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SorceryManager.levelIndex == layerIndex)
        {
            //SorceryManager sorceryManager = sorcery.GetComponentInParent<SorceryManager>();
            transform.parent = null;
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine(Fall());
            Barto barto = bartolomeu.GetComponentInParent<Barto>();
            barto.ResetSpeed();
        }


    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);


    }
}
