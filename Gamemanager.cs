using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public int lives;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*int playerAmount = FindObjectsOfType<Player_Movement>().Length;
        if (playerAmount <= 0)
        {
            playerDeath();
        }*/
    }

    public void playerDeath()
    {
        if (lives > 0)
        {
            //If player is dead and there is more than one life, player will respawn on the current scene and decrease one life
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);   
            lives -= 1;
        }
        else
        {
            //if player id dead and there is no more lifes, player will respawn at the start of the first scene and destroy scene persist and this object
            Destroy(FindObjectOfType<scenepersisit>().gameObject);
            Destroy(FindObjectOfType<powerupScene>().gameObject);
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }
    }

}
