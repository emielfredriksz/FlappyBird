using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public GameObject coin;
    public float spawnRate = 2;
    public float offset = 10;
    private float timer = 0;
    private float xOffset = 0;
    private int count = 1;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
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
            spawnPipe();
            count++;
            if (count == 3)
            {
                spawnCoin();
                count = 0;
            }
            timer = 0;
        }
    }

    void spawnPipe()
    {
        xOffset = Random.Range((float)0.3, 1) * offset;
        xOffset *= (int)Random.Range(0, 2)==1 ? 1 : -1;
        Vector3 newPosition = transform.position + new Vector3(0, xOffset);
        Instantiate(pipe, newPosition, transform.rotation);
    }

    void spawnCoin()
    {
        xOffset = Random.Range((float)0.6, 1) * offset;
        xOffset *= (int)Random.Range(0, 2) == 1 ? 1 : -1;
        Vector3 newPosition = transform.position + new Vector3(10, xOffset);
        Instantiate(coin, newPosition, transform.rotation);
    }
}
