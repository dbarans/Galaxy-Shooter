using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followScript : MonoBehaviour
{
    public GameObject target;
    void Update()
    {
        Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        transform.position = newPos;
    }
}