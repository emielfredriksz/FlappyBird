using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHighScore : MonoBehaviour
{

    public Text scoreText;
    public Text coinText;
    private int score;
    private int coin;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("Highscore", 0);
        scoreText.text = score.ToString();

        coin = PlayerPrefs.GetInt("CoinCount", 0);
        coinText.text = "$"+coin.ToString();
    }
}
