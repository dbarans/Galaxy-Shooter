using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public int health;
    public int reward;
    public logicScript logic;
    public GameObject playerBullet;
    public AudioSource sound; 

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        sound = GameObject.FindGameObjectWithTag("explosion").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("bullet 1"))
        {
            health = health - 1;
            if (health < 1)
            {

                logic.addScore(reward);
                sound.Play();
                Destroy(gameObject);
            }
        }


    }



}

