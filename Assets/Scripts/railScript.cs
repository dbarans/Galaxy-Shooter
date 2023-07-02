using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class railScript : MonoBehaviour
{
    public float speed;
    public float offset = 8f;
    private bool left_way = true;


    void Start()
    {
        float randomPositionX = Random.Range(-8f, 8f);
        transform.position = new Vector3(randomPositionX, transform.position.y, transform.position.z);
        if (randomPositionX < 0)
        {
            left_way = false;
        }
    }


    void Update()
    {
        if (transform.position.x > offset)
        {
            left_way = true;
        }
        if (transform.position.x < -offset)
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