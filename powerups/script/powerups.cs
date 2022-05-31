using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum typeOfPowerup
{
    getGun,
    health,
    speed,
    dmg,
    control,
    atkSpeed
}

public class powerups : MonoBehaviour
{
    public float amountOFHealthWantToGive;
    public float amountOFSpeedWantToGive;
    public float amountOfAtkSpeedIncrease;

    public typeOfPowerup powerupType;

    Player_Movement playermMove;
    Player_Attack playeratk;
    powerUpGive powerup;

    // Start is called before the first frame update
    void Start()
    {
        playeratk = FindObjectOfType<Player_Attack>().GetComponent<Player_Attack>();
        playermMove = FindObjectOfType<Player_Movement>().GetComponent<Player_Movement>();
        powerup = FindObjectOfType<powerUpGive>().GetComponent<powerUpGive>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            if (powerupType == typeOfPowerup.getGun)
            {
                powerup.hasGun = true;
            }
            else if (powerupType == typeOfPowerup.health)
            {
                powerup.givehealthAmount += amountOFHealthWantToGive;
            }
            else if (powerupType == typeOfPowerup.control)
            {
                powerup.inControl = true;
            }
            else if (powerupType == typeOfPowerup.atkSpeed)
            {
                powerup.increaseAtkRate += amountOfAtkSpeedIncrease;
            }
            Destroy(gameObject);
        }
    }
}
