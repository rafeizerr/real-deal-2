using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreScript : MonoBehaviour
{
     public string color;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HideCore()
    {
        gameObject.SetActive(false);
        Debug.Log("vou me esconder!");
    }
    public void DisplayCore()
    {

        gameObject.SetActive(true);
    }
    
       private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            if(bullet.color == color)
            {
                Debug.Log("acertou");
            }
            else
            {
                Debug.Log("errou");
            }
        }
    }
}
