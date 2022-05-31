using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxx_place : MonoBehaviour
{

    [SerializeField] GameObject lazer;
    [SerializeField] GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(spawnLazer());
            healthBar.SetActive(true);
            FindObjectOfType<enemy_Boss>().takeDmg = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        { 
            FindObjectOfType<enemy_Boss>().bossShoot();
        }
    }

    IEnumerator spawnLazer()
    {
        yield return null;
        yield return new WaitForSeconds(2);
        lazer.SetActive(true);
    }
}
