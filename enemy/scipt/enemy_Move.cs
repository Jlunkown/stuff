using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemyState
{
    walking,
    atking
}
public class enemy_Move : MonoBehaviour
{
    //to make it work
    bool mayRotate;


    //game object
    GameObject player;


    //component
    Player_Attack playerAtk;
    Rigidbody2D enemyrb;
    Animator anim;
    enemyState state;


    //stats
    #region stats
    //moving
    [SerializeField] float speed = 10;
    [SerializeField] float stoppingDistance = 5;
    [SerializeField] float detectingDistance = 30;
    float detectDistance;
    float currentExpandRadiustime;

    //health
    float health = 200;

    //attacking
    [SerializeField] GameObject bullet;

    [SerializeField] bool rangeAtker;
    [SerializeField] float atkRate;
    [SerializeField] float nextTimeToAtk;
    float dmg;
    #endregion

    void Start()
    {
        //setting things up at the start
        playerAtk = FindObjectOfType<Player_Attack>().GetComponent<Player_Attack>();
        player = FindObjectOfType<Player_Movement>().gameObject;
        enemyrb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        detectDistance = detectingDistance;
    }

    void Update()
    {
        movingAndRotating();
        die();

        //attacking
        if (nextTimeToAtk > 0)
        {
            nextTimeToAtk -= Time.deltaTime;
        }

        //expand detecting radius
        #region expand detecting radius
        if (currentExpandRadiustime > 0)
        {
            detectingDistance *= 3;
            currentExpandRadiustime -= Time.deltaTime;
        }
        else
        {
            detectingDistance = detectDistance;
        }

        #endregion
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "bullet")
        {
            Destroy(other.gameObject);
            health -= playerAtk.bulletDmg;
            currentExpandRadiustime = 2;
        }
    }

    void movingAndRotating()
    {
        //moving
        if (state == enemyState.walking)
        {
            if (Vector2.Distance(transform.position, player.transform.position) < detectingDistance)
            {
                anim.SetBool("moving", true);
                if (Vector2.Distance(transform.position, player.transform.position) > stoppingDistance)
                {
                    transform.Translate(Vector2.up * speed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, player.transform.position) < stoppingDistance && nextTimeToAtk <= 0)
                    {
                        StartCoroutine(rangeAtkCo());
                    }
                }
            }
            else 
            {
                anim.SetBool("moving", false);
            }
        }
        

        //rotating
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        enemyrb.rotation = angle;
    }

    void attacking()
    {
        if (rangeAtker)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            nextTimeToAtk = atkRate;
        }
    }

    void die()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //courotines
    #region courotines
    private IEnumerator rangeAtkCo()
    {
        //attacking, swithcing states, and waiting
        state = enemyState.atking;
        anim.SetBool("moving", false);
        yield return null;
        attacking();
        yield return new WaitForSeconds(atkRate);
        state = enemyState.walking;
    }
    #endregion
}
