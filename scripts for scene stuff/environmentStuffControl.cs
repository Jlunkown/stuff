using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class environmentStuffControl : MonoBehaviour
{
    [SerializeField] bool hvKey;

    [SerializeField] GameObject whatToDestroy;
    [SerializeField] GameObject gateToDestroy;
    [HideInInspector] public bool openPlayButton;
    [SerializeField] GameObject playButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int enemyCount;
        enemyCount = FindObjectsOfType<enemy_Move>().Length;

        if (enemyCount <= 0)
        {
            Destroy(whatToDestroy);
        }

        int keyCount = FindObjectsOfType<key>().Length;
        if (keyCount <= 0)
        {
            Destroy(gateToDestroy);
        }
    }
}
