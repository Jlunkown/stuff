using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow_Player : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = FindObjectOfType<Player_Attack>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(0, 0, -10);
        transform.position = player.transform.position + offset;

        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
