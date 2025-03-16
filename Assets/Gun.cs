using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Bullet bullet;
    Vector2 direction;
    public bool isActive = false;

    Camera cam;
    //fazer lista de bullets
    //usando listas
    //qnd dragon faz algo a lista anda e muda a bullet

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;


    }

    // Update is called once per frame
    void Update()
    {
        //direction = (transform.localRotation * Vector2.right).normalized;
        //direction = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = transform.position.z;

        direction = (mouseWorldPosition - transform.position).normalized;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }


    }

    public void Shoot()
    {
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        Bullet goBullet = go.GetComponent<Bullet>();
        goBullet.direction = direction;
    }

}
