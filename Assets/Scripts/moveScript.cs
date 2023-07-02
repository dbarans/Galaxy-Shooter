using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    public float speed;
    public State direction;
    public enum State
    {
        Up,
        Down
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (direction == State.Up)
        {
            transform.position = transform.position + (Vector3.up * Time.deltaTime * speed);
        }
        else
        {
            transform.position = transform.position - (Vector3.up * Time.deltaTime * speed);
        }

    }
}
