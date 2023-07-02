using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScript : MonoBehaviour
{
    public float offset = 20.47f;
    public float depth;
    public GameObject secondImage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -offset)
        {
            transform.position = new Vector3(0, offset, depth);
            secondImage.transform.position = new Vector3(0, 0, depth);
        }
    }
}