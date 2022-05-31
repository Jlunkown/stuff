using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupScene : MonoBehaviour
{
    void Awake()
    {
        int numScenePersist = FindObjectsOfType<powerupScene>().Length;
        if (numScenePersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void destroyPowerUp()
    {
        Destroy(gameObject);
    }
}
