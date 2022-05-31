using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bossText;
    [SerializeField] Slider slider;
    float maxvalueHealthPlayerBoss;
    enemy_Boss boss;

    // Start is called before the first frame update
    void Start()
    {
        boss = FindObjectOfType<enemy_Boss>();
        slider.maxValue = boss.health;
    }

    // Update is called once per frame
    void Update()
    {
        slider.minValue = 0;

        slider.value = boss.health;
        bossText.text = boss.health + "/6000";
    }
}
