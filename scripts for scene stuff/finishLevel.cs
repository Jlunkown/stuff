using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishLevel : MonoBehaviour
{
    [SerializeField] int whatSceneToLoad;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            int sceneIndexNow = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene(whatSceneToLoad);
            Destroy(FindObjectOfType<scenepersisit>().gameObject);
            Destroy(FindObjectOfType<powerupScene>().gameObject);
            FindObjectOfType<playGame>().playGameOpen = true;
            
            if (sceneIndexNow == 1)
            {
                FindObjectOfType<playGame>().level1Done = true;
            }
            else if (sceneIndexNow == 2)
            {
                FindObjectOfType<playGame>().level2Done = true;
            }
            else if (sceneIndexNow == 3)
            {
                FindObjectOfType<playGame>().level3Done = true;
            }
            else if (sceneIndexNow == 4)
            {
                FindObjectOfType<playGame>().level4Done = true;
            }
            else if (sceneIndexNow == 5)
            {
                FindObjectOfType<playGame>().level5Done = true;
            }
        }
    }
}
