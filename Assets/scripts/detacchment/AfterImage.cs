using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage : MonoBehaviour
{

    public float repeatRate;

   void Start()
    {
        InvokeRepeating("SpawnTrail", 0, repeatRate); // replace 0.2f with needed repeatRate
    }

    void SpawnTrail()
    {
        GameObject trailPart = new GameObject();
        SpriteRenderer trailPartRenderer = trailPart.AddComponent<SpriteRenderer>();
        trailPartRenderer.sprite = GetComponent<SpriteRenderer>().sprite;
        trailPart.transform.position = transform.position;
        Destroy(trailPart, 0.5f); // replace 0.5f with needed lifeTime

        StartCoroutine("FadeTrailPart", trailPartRenderer);
    }

    IEnumerator FadeTrailPart(SpriteRenderer trailPartRenderer)
    {
        Color color = trailPartRenderer.color;
        color.a -= 0.8f; // replace 0.5f with needed alpha decrement
        trailPartRenderer.color = color;

        yield return new WaitForEndOfFrame();
    }
}
