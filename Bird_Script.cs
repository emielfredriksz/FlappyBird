using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird_Script : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public float normalGravity = 6;
    public float deathGravity = 10;
    public float timer = -1;
    public bool timerOn = false;
    public GameObject menu;
    public Text scoreText;
    public Sprite[] SpriteArray;
    public AudioSource[] SoundArray;
    public int key_code;

    // Start is called before the first frame update
    void Start()
    {
        UpdateSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.firstGame)
        {
            myRigidbody.gravityScale = 0;
        }
        else
        {
            if (logic.gameOn)
            {
                myRigidbody.gravityScale = normalGravity;

                for (int i = 0; i < Input.touchCount; i++)
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        myRigidbody.velocity = Vector2.up * flapStrength;
                        SoundArray[3].Play();
                    }
                }

                if (Input.GetKeyDown((KeyCode) key_code) == true)
                {
                    myRigidbody.velocity = Vector2.up * flapStrength;
                    SoundArray[3].Play();
                }

            }
            else
            {
                if (!timerOn)
                {
                    timerOn = true;
                    timer = 3;
                }
                myRigidbody.gravityScale = deathGravity;
                myRigidbody.rotation += 2;

                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                else if (timer < 0 && timer > -1)
                {
                    menu.SetActive(true);
                    logic.getScore();
                    timer = -1;
                }
            }
        }
        
    }

    public void UpdateSprite()
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        if (PlayerPrefs.GetInt("BlueBird", 0) == 0 && PlayerPrefs.GetInt("GoldBird", 0) == 0)
            renderer.sprite = SpriteArray[0];
        if (PlayerPrefs.GetInt("BlueBird", 0) == 1)
        {
            renderer.sprite = SpriteArray[1];
        }
        if (PlayerPrefs.GetInt("GoldBird", 0) == 1)
        {
            renderer.sprite = SpriteArray[2];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pipe")
        {
            if (!logic.dead)
            {
                logic.dead = true;
                /*if (logic.playerScore < 10)
                    SoundArray[0].Play();
                else if (logic.playerScore >= 10 && logic.playerScore < 20)
                    SoundArray[1].Play();
                else
                    SoundArray[2].Play();*/
            }
            logic.gameOn = false;
            int newScore = int.Parse(scoreText.text);
            if (newScore > PlayerPrefs.GetInt("Highscore", 0))
                PlayerPrefs.SetInt("Highscore", newScore);
        }
    }
}
