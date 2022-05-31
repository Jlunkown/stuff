using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarScript : MonoBehaviour
{

    [SerializeField] Slider slider;
    float maxvalueHealthPlayer;

    Player_Movement player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_Movement>();
        slider.maxValue = player.health;
    }

    // Update is called once per frame
    void Update()
    {
        slider.minValue = 0;

        slider.value = player.health;
    }
}
