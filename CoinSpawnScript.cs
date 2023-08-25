using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnScript : MonoBehaviour
{
    public GameObject coin;
    public float spawnRate = 4;
    public float offset = 10;
    private float timer = 1;
    private float xOffset = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnCoin();
            timer = 0;
        }
    }

    void spawnCoin()
    {
        xOffset = Random.Range((float)0.6, 1) * offset;
        xOffset *= (int)Random.Range(0, 2)==1 ? 1 : -1;
        Vector3 newPosition = transform.position + new Vector3(0, xOffset);
        Instantiate(coin, newPosition, transform.rotation);
    }
}
