using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDragon : MonoBehaviour
{
    Gun[] guns;
    bool shoot;
    // Start is called before the first frame update
    void Start()
    {
        guns = transform.GetComponentsInChildren<Gun>();
        foreach (Gun gun in guns)
        {
            gun.isActive = true;
            /*
            //desativa guns com power up level requirement diferente de zero
            if (gun.powerUpLevelRequirement != 0)
            {
                gun.gameObject.SetActive(false);
            }
            */
        }

    }


    // Update is called once per frame
    void Update()
    {
        shoot = Input.GetKeyDown(KeyCode.X);

        if (shoot)
        {
            shoot = false;
            foreach (Gun gun in guns)
            {
                if (gun.gameObject.activeSelf)
                {
                    gun.Shoot();
                }
            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        //Quaternion rot = transform.rotation;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.y = 3.0f;
            pos.x = 0;
            //rot.z = -90;
            transform.rotation = Quaternion.Euler(0, 00, -90);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.y = -3.0f;
            pos.x = 0;
            //rot.z = 0;
            transform.rotation = Quaternion.Euler(0, 00, 90);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x = -6.0f;
            pos.y = 0;
            //rot.y = 0;
            transform.rotation = Quaternion.Euler(0, 00, 00);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x = 6.0f;
            pos.y = 0;
            //rot.y = 0;
            transform.rotation = Quaternion.Euler(0, 180, 00);
        }
        transform.position = pos;
        //transform.rotation = rot;


    }


}

