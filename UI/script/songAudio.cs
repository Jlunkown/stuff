using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songAudio : MonoBehaviour
{
    bool isMuted;
    AudioSource audiosource;
    void Awake()
    {
        int numScenePersist = FindObjectsOfType<songAudio>().Length;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            muteAudio();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            audiosource.volume = 0.3f;
        }
    }

    public void muteAudio()
    {
        audiosource = GetComponent<AudioSource>();
        if (isMuted)
        {
            audiosource.volume = 0.3f;
            isMuted = false;
        }
        else
        {
            audiosource.volume = 0;
            isMuted = true;
        }
    }

}
