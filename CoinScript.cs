using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private LogicScript logic;

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
                int price = (1 + logic.playerScore / 10);
                logic.addMoney(price);
                Destroy(gameObject);
            }
        }
    }
}