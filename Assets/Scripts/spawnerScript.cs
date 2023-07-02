using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public GameObject obj;
    private float timer = 0f;
    public float timeSpawn = 1f;
    public bool isOn;
    public float depth = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < timeSpawn)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnObj();
            timer = 0;

        }
    }


    void spawnObj()
    {
        if (isOn)
        {
            Instantiate(obj, new Vector3(transform.position.x, transform.position.y, depth), transform.rotation);
        }

    }
}
