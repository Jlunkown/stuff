using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] float speed = 40;
    float timeBeforeDestroySelf = 5;
    public float atk; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (timeBeforeDestroySelf <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            timeBeforeDestroySelf -= Time.deltaTime;
        }
    }

}
