using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Boss : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;

    public bool takeDmg;

    public float health;
    [SerializeField] float ammo;
    [SerializeField] float currentAmmo;
    [SerializeField] float atkRate;
    [SerializeField] float reloadTime;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject gunPoint;

    [SerializeField] GameObject bossPlace;
    [SerializeField] GameObject bossHealthBar;
    float nextTimeToAtk;

    // Start is called before the first frame update
    void Awake()
    {
        currentAmmo = ammo;
        player = FindObjectOfType<Player_Movement>().gameObject;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;

        die();

        if (nextTimeToAtk > 0)
        {
            nextTimeToAtk -= Time.deltaTime;
        }
    }

    public void bossShoot()
    {
        if (currentAmmo > 0)
        {
            if (nextTimeToAtk <= 0)
            {
                Instantiate(bullet, gunPoint.transform.position, transform.rotation);
                currentAmmo -= 1;
                nextTimeToAtk = atkRate;
            }
            else
            {
                nextTimeToAtk -= Time.deltaTime;
            }
        }
        else
        {
            Reload();
        }
    }

    void Reload()
    {
        StartCoroutine(reload());
    }

    void die()
    {
        if (health <= 0)
        {
            Destroy(bossPlace);
            Destroy(bossHealthBar);
            Destroy(gameObject);
        }
    }

    IEnumerator reload()
    {
        yield return null;
        yield return new 
        WaitForSeconds(reloadTime);
        currentAmmo = ammo;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet" && takeDmg)
        {
            health -= FindObjectOfType<Player_Attack>().bulletDmg;
        }
    }
}
