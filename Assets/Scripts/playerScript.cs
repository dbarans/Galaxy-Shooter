using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float speed = 8f;
    private float maxWidth = 8.35f;
    private float maxHeight = 4.53f;
    public int health = 3;
    public bool immune = false;
    private float timer = 0f;
    private float immuneTime = 3f;
    public spawnerScript bulletSpawner1;
    public spawnerScript bulletSpawner2;
    public spawnerScript bulletSpawner3;
    private int rifleQuantity = 1;
    private bool render;
    public logicScript logic;
    public AudioSource explosionSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (immune)
        {
            immuneClock();
            if (render)
            {
                render = false;
            }
            else
            {
                render = true;
            }
            gameObject.GetComponent<Renderer>().enabled = render;
        }
        playerMove();
    }
    void playerMove()
    {

        if (Input.GetAxis("Horizontal") > 0 & transform.position.x < maxWidth)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0, 0);
        }
        if (Input.GetAxis("Horizontal") < 0 & transform.position.x > -maxWidth)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0, 0);
        }
        if (Input.GetAxis("Vertical") > 0 & transform.position.y < maxHeight)
        {
            transform.position += new Vector3(0, Input.GetAxis("Vertical") * Time.deltaTime * speed, 0);
        }
        if (Input.GetAxis("Vertical") < 0 & transform.position.y > -maxHeight)
        {
            transform.position += new Vector3(0, Input.GetAxis("Vertical") * Time.deltaTime * speed, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!immune)
        {
            if (other.gameObject.name.Contains("Enemy") || other.gameObject.name.Contains("bullet 2"))
            {
                decreaseHealth(1);
                immune = true;
                changeRiffle(-2);
                speed = 8f;
                explosionSound.Play();

            }
        }
        if (other.gameObject.name.Contains("heart"))
        {
            decreaseHealth(-1);
        }
        if (other.gameObject.name.Contains("ammo"))
        {
            changeRiffle(1);
        }
        if (other.gameObject.name.Contains("lightning"))
        {
            changeSpeed();
        }

    }

    void game_over()
    {
        Destroy(gameObject);
        logic.gameOver();

    }
    void decreaseHealth(int quantity)
    {
        health = health - quantity;
        if (health > 5)
        {
            health = 5;
            logic.addScore(5);
        }
        logic.changeHealth(health);
        if (health < 1)
        {
            game_over();
        }

    }

    void changeRiffle(int quantity)
    {
        rifleQuantity = rifleQuantity + quantity;
        if (rifleQuantity > 3)
        {
            rifleQuantity = 3;
            logic.addScore(5);
        }
        if (rifleQuantity < 1)
        {
            rifleQuantity = 1;
        }
        if (rifleQuantity == 1)
        {
            bulletSpawner1.isOn = true;
            bulletSpawner2.isOn = false;
            bulletSpawner3.isOn = false;
        }
        if (rifleQuantity == 2)
        {
            bulletSpawner1.isOn = false;
            bulletSpawner2.isOn = true;
            bulletSpawner3.isOn = true;
        }
        if (rifleQuantity == 3)
        {
            bulletSpawner1.isOn = true;
            bulletSpawner2.isOn = true;
            bulletSpawner3.isOn = true;
        }
        Debug.Log(rifleQuantity);
    }
    void changeSpeed()
    {
        speed = speed + 2;
        if (speed > 16)
        {
            speed = 16f;
            logic.addScore(5);
        }

    }

    void immuneClock()
    {
        if (timer < immuneTime)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            timer = 0;
            immune = false;
            render = false;

        }
    }

}
