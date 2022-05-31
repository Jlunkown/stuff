using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playGame : MonoBehaviour
{
    [HideInInspector] public bool playGameOpen;
    [HideInInspector] public bool level1Done;
    [HideInInspector] public bool level2Done;
    [HideInInspector] public bool level3Done;
    [HideInInspector] public bool level4Done;
    [HideInInspector] public bool level5Done;
    void Awake()
    {
        int numScenePersist = FindObjectsOfType<playGame>().Length;
        if (numScenePersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {

    }

    public void destroyScenePersist()
    {
        Destroy(gameObject);
    }
}
