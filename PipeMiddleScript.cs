using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    private LogicScript logic;
    public AudioSource point;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (logic.gameOn)
        {
            if (collision.gameObject.layer == 3)
            {
                logic.addScore();
                point.Play();
            }
        }
    }
}
