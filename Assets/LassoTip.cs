using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LassoTip : MonoBehaviour
{
    Camera cam;
    public GameObject tip;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 tipPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        tip.transform.position = tipPosition;

    }
}
