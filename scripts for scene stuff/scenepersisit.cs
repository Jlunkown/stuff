using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenepersisit : MonoBehaviour
{
    void Awake()
    {
        int numScenePersist = FindObjectsOfType<scenepersisit>().Length;
        if (numScenePersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void destroyScenePersist()
    {
        Destroy(gameObject);
    }

}
