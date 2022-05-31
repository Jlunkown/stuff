using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{   
    //game object
    [SerializeField] GameObject gun;
    [SerializeField] GameObject bullet;


    //components
    powerUpGive powerup;


    //variables and stats
    bool hasGun;
    [SerializeField] float atkRate;
    float nextTimeToAtk;
    public float bulletDmg;

    // Start is called before the first frame update
    void Awake()
    {
        powerup = FindObjectOfType<powerUpGive>().GetComponent<powerUpGive>();

        //give stat stuff
        hasGun = powerup.hasGun;
        atkRate -= powerup.increaseAtkRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasGun)
        {
            shoot();
        }
    }

    void shoot()
    {
        gun.SetActive(true);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (nextTimeToAtk <= 0)
            {
                Instantiate(bullet, transform.position, transform.rotation);
                nextTimeToAtk = atkRate;
            }
        }
        if (nextTimeToAtk > 0)
        {
            nextTimeToAtk -= Time.deltaTime;
        }
    }

}
