using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LassoManager : MonoBehaviour
{
    public Camera camera;

    public LassoScript lassoScript;
    public CapturePoint capturePoint;
    private LassoScript currentLasso;

    public static string hue;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void DeactivateLasso()
    {
        GameObject[] lassos = GameObject.FindGameObjectsWithTag("Lasso");
        foreach (GameObject lasso in lassos)
            GameObject.Destroy(lasso);
        GameObject[] caps = GameObject.FindGameObjectsWithTag("CapturePoint");
        foreach (GameObject cap in caps)
            GameObject.Destroy(cap);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            currentLasso = Instantiate(lassoScript, mousePosition, Quaternion.identity);
            Instantiate(capturePoint, mousePosition, Quaternion.identity);
        }

        if (Input.GetMouseButton(0))
        {
            currentLasso.SetPosition(mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            GameObject[] lassos = GameObject.FindGameObjectsWithTag("Lasso");
            foreach (GameObject lasso in lassos)
            {
                GameObject.Destroy(lasso);
                LassoScript.colorIndex = 0;
            }

            GameObject[] caps = GameObject.FindGameObjectsWithTag("CapturePoint");
            foreach (GameObject cap in caps)
            {
                GameObject.Destroy(cap);
            }
        }

    }
}
