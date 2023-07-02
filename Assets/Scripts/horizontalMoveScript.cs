using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalMoveScript : MonoBehaviour
{
    public float speed;
    public float offset;
    private float min_offset;
    private float max_offset;
    private bool left_way = true;
    // Start is called before the first frame update
    void Start()
    {
        max_offset = transform.position.x + offset;
        min_offset = transform.position.x - offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > max_offset)
        {
            left_way = true;
        }
        if (transform.position.x < min_offset)
        {
            left_way = false;
        }
        move();
    }

    void move()
    {

        if (left_way)
        {
            transform.position = transform.position + (Vector3.left * Time.deltaTime * speed);
        }
        else
        {
            transform.position = transform.position - (Vector3.left * Time.deltaTime * speed);
        }
    }
}
