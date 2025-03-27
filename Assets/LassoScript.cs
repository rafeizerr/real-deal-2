using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LassoScript : MonoBehaviour
{
    public LineRenderer lineRenderer;

    public EdgeCollider2D edgeCol;
    private List<Vector2> points = new List<Vector2>();

    //Material materials;
    //[SerializeField] private Material[] materials;

    [SerializeField] Material[] lassoMaterial;

    public static int colorIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        edgeCol.transform.position -= transform.position;
        lineRenderer.material = lassoMaterial[colorIndex];




    }

    // Update is called once per frame
    void Update()
    {



    }

    public void SetPosition(Vector2 pos)
    {
        if (!CanAppend(pos))
        {
            return;
        }

        points.Add(pos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, pos);

        edgeCol.points = points.ToArray();
    }

    private bool CanAppend(Vector2 pos)
    {
        if (lineRenderer.positionCount == 0)
        {
            return true;
        }

        return Vector2.Distance(lineRenderer.GetPosition(lineRenderer.positionCount - 1), pos) > 0.1f;
    }
}
