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

        direction = (transform.localRotation * Vector2.right).normalized;


    }

    public void Up()
    {
        transform.rotation = Quaternion.Euler(0, 00, -90);
    }
    public void Down()
    {
        transform.rotation = Quaternion.Euler(0, 00, 90);

    }
    public void Left()
    {
        transform.rotation = Quaternion.Euler(0, 00, 00);
    }
    public void Right()
    {
        transform.rotation = Quaternion.Euler(0, 180, 00);
    }

    public void Shoot()
    {
        GameObject go = Instantiate(bullet.gameObject, transform.position, transform.rotation);
        Bullet goBullet = go.GetComponent<Bullet>();
        goBullet.direction = (Vector2)transform.right;
    }

}
