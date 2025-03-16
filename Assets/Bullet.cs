using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction = new Vector2(0, 1);
    public float speed = 2;
    public Vector2 velocity;

    public float timeToSelfDestruct;
    public float selfDestructTimer;

    public string color;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (selfDestructTimer >= timeToSelfDestruct)
        {
            Destroy(gameObject);
        }
        else
        {
            selfDestructTimer += Time.deltaTime;
        }

        velocity = direction * speed;

    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;
    }
}
