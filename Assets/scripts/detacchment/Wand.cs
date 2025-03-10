using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    public bool isCutting = false;
    Rigidbody2D rb;
    Camera cam;
    public GameObject trailPrefab;
    GameObject currentTrail;
    CircleCollider2D circleCollider;
    Vector2 previousPosition;
    public float minCutVelocity;
    public int power;
    PowerBar powerBar;
    public GameObject bar;
    public GameObject blade;

    void Start()
    {
        power = 0;
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bladePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        blade.transform.position = bladePosition;
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateCut();
        }

        if (Input.GetMouseButtonDown(1))
        {
            DefinePower();
        }
    }

    void UpdateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;
        
        

        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
        if (velocity > minCutVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }

        previousPosition = newPosition;
    }

    void StartCutting()
    {

        isCutting = true;
        currentTrail = Instantiate(trailPrefab, transform);
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled = false;
    }

    void StopCutting()
    {
        isCutting = false;
        currentTrail.transform.SetParent(null);
        Destroy(currentTrail, 0.5f);
        circleCollider.enabled = false;
    }

    void DefinePower()
    {
        if (PowerBar.strong)
        {
            power = 100;
        }
        else if (PowerBar.mid)
        {
            power = 50;
        }
        else if (PowerBar.weak)
        {
            power = 25;
        }
        powerBar = bar.GetComponent<PowerBar>();
        powerBar.DeactivateBar();


    }
}
