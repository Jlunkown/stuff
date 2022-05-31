using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class button : MonoBehaviour
{

    public int levelToOpen;
    [SerializeField] bool isMuted;

    GameObject songAudioSource;
    songAudio songaudio;

    [SerializeField] GameObject whatToOpen;
    [SerializeField] GameObject currentScreen;
    [SerializeField] GameObject player;
    [SerializeField] GameObject playButton;
    [SerializeField] TextMeshProUGUI buttonText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play()
    {
        SceneManager.LoadScene(levelToOpen);
    }

    public void playTutorial()
    {
        playButton.SetActive(true);
        SceneManager.LoadScene(levelToOpen);
    }

    public void openAnotherPlace()
    {
        whatToOpen.SetActive(true);
        currentScreen.SetActive(false);
    }

    public void teleportTutorial()
    {
        player.transform.position = FindObjectOfType<finishLevel>().gameObject.transform.position;
    }

    public void quitLevel()
    {
        SceneManager.LoadScene(0);
        Destroy(FindObjectOfType<scenepersisit>().gameObject);
        Destroy(FindObjectOfType<powerupScene>().gameObject);
    }

    public void muteAudio()
    {
        songAudioSource = FindObjectOfType<songAudio>().gameObject;
        songaudio = FindObjectOfType<songAudio>().GetComponent<songAudio>();
        songaudio = songAudioSource.GetComponent<songAudio>();
        songaudio.muteAudio();
        
        if (isMuted == true)
        {
            buttonText.text = "Umute";
        }
        else
        {
            buttonText.text = "mute";
        }
    }

}
