using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //gameobjects
    [SerializeField] Camera cam;
    [SerializeField] GameObject gun;
    [SerializeField] GameObject wings;
    [SerializeField] GameObject shield;

    //component outside game object
    Gamemanager gamemanager;
    powerUpGive powerup;
    Animator anim;

    //component
    Rigidbody2D playerrb;
    Rigidbody2D gunrb;

    enemy_Move enemy;
    bullet bullet;

    //stats
    public float speed;
    public float ForceSpeed;
    public float health;

    public bool inControl;


    //vector
    Vector2 movement;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Awake()
    {
        powerup = FindObjectOfType<powerUpGive>().GetComponent<powerUpGive>();
        playerrb = gameObject.GetComponent<Rigidbody2D>();
        gunrb = gun.GetComponent<Rigidbody2D>();
        gamemanager = GameObject.Find("Gamemanager").GetComponent<Gamemanager>();
        anim = gameObject.GetComponent<Animator>();

        //give stats stuff
        health += powerup.givehealthAmount;
        inControl = powerup.inControl;
    }

    // Update is called once per frame
    void Update()
    {
        movementAndRotating();
        die();

        if (health > 200)
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }
    }

    void movementAndRotating()
    {
        //movement
        //if got the powerup of in control(can control the player)
        if (inControl)
        {
            wings.SetActive(true);
            //movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            transform.Translate(movement * speed * Time.deltaTime);

            //playerrb.MovePosition(playerrb.position + movement * speed * Time.deltaTime);
            //playerrb.AddForce(transform.up * speed * movement);

            //animating
            #region animating
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                anim.SetBool("moving", true);
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                anim.SetBool("moving", false);
            }
            #endregion
        }
        else
        {
            //before getting the powerup of in control(use force to move the player)
            if (!inControl)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    playerrb.AddForce(transform.up * ForceSpeed);
                    anim.SetBool("moving", true);
                }
                if (Input.GetKeyUp(KeyCode.W))
                {
                    anim.SetBool("moving", false);
                }
                
            }
        }

        //rotating
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 LookingDir = mousePos - playerrb.position;
        float angle = Mathf.Atan2(LookingDir.y, LookingDir.x) * Mathf.Rad2Deg - 90f;
        playerrb.rotation = angle;
    }

    void die()
    {
        if (health <= 0)
        {
            gamemanager.playerDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "enemyBullet")
        {
            Destroy(other.gameObject);
            health -= other.GetComponent<bullet>().atk;
        }    
    }

}
