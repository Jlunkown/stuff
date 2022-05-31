using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneStuff : MonoBehaviour
{

    [SerializeField] GameObject playButton;
    [SerializeField] GameObject level2;
    [SerializeField] GameObject level3;
    [SerializeField] GameObject level4;
    [SerializeField] GameObject level5;
    playGame playGame;

    // Start is called before the first frame update
    void Start()
    {
        playGame = FindObjectOfType<playGame>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playGame.playGameOpen)
        {
            playButton.SetActive(true);
        }
        if (playGame.level1Done)
        {
            level2.SetActive(true); 
        }
        if (playGame.level2Done)
        {
            level3.SetActive(true);
        }
        if (playGame.level3Done)
        {
            level4.SetActive(true);
        }
        if (playGame.level4Done)
        {
            level5.SetActive(true);
        }
    }   
}
