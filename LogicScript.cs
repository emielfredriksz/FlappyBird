using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int coinCount;
    public Text scoreText;
    public Text coinText;
    private Text menuScoreText;
    private Text menuCoinText;
    public bool gameOn = false;
    public bool firstGame = true;
    public bool dead = false;
    public AudioSource sound;

    public void Start()
    {
        init();
    }

    public void init()
    {
        coinCount = PlayerPrefs.GetInt("CoinCount", 0);
        coinText.text = "$" + coinCount.ToString();
        scoreText.text = "0";
    }

    public void addScore()
    {
        playerScore += 1;
        scoreText.text = playerScore.ToString();
    }

    public void addMoney(int i = 1)
    {
        coinCount += i;
        sound.Play();
        PlayerPrefs.SetInt("CoinCount", coinCount);
        coinText.text = "$"+coinCount.ToString();
    }

    public void getScore()
    {
        menuScoreText = GameObject.FindGameObjectWithTag("Highscore").GetComponent<Text>();
        menuScoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }
}
