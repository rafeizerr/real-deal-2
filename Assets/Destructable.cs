using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


private void OnTriggerEnter(Collider collision)
    {
          if (collision.gameObject.name == "Espada")
         {
            Destroy(gameObject);
            
         }
    }
}
