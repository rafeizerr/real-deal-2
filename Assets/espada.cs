using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class espada : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.X))
        {
            StartCoroutine(Slice());
        }
        
    }

    IEnumerator Slice()
    {
        transform.rotation = Quaternion.Euler(62, -16, 91);
        transform.position = new Vector3(0.53f, -0.08f, 1.5f);
        yield return new WaitForSeconds(0.5f);
        transform.rotation = Quaternion.Euler(42, -16, 91);
        transform.position = new Vector3(0.9f, 0f, 1.5f);

    }
}
