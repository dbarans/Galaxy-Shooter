using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public logicScript logic;
    public AudioSource sound1;
    public AudioSource sound2;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        playSound();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 10 || transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Enemy") || other.gameObject.name.Contains("player"))
        {
            Destroy(gameObject);
        }
    }
    void playSound()
    {
        name = gameObject.name;
        if (name.Contains("bullet 1"))
        {
            sound1 = GameObject.FindGameObjectWithTag("bullet 1").GetComponent<AudioSource>();
            sound1.Play();
        }
        if (name.Contains("bullet 2"))
        {
            sound2 = GameObject.FindGameObjectWithTag("bullet 2").GetComponent<AudioSource>();
            sound2.Play();
        }
    }
}
