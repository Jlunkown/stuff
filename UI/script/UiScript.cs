using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UiScript : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject healthbar;
    float maxHealth;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI healthText;
 
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = FindObjectOfType<Player_Movement>().health;
        livesText.text = "" + FindObjectOfType<Gamemanager>().lives;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            healthbar.SetActive(false);
        }

        healthText.text = FindObjectOfType<Player_Movement>().health + "/" + maxHealth;

    }
}
