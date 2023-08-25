using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class menuLogic : MonoBehaviour
{
    public GameObject shop;
    public GameObject menu;
    public LogicScript logic;
    public GameObject spawner;
    public string[] tags;
    public GameObject[] birds;
    private Dictionary<string, item> items =
        new Dictionary<string, item>()
        {
            {"BlueBird", new item(73, 5)},
            {"GoldBird", new item(107, 99)},
        };

    private void Start()
    {
    }

    public void updateItems()
    {
        
        foreach (string tag in tags)
        {
            GameObject item = GameObject.FindWithTag(tag);
            Text text = item.GetComponent<Text>();
            RectTransform rect = item.GetComponent<RectTransform>();
            if (PlayerPrefs.GetInt(tag, 0) == 1)
            { 
                text.text = "SOLD";
                rect.sizeDelta = new Vector2(185, (int)rect.sizeDelta.y);
                item.GetComponentInParent<Button>().interactable = false;
            }
            else
            {
                text.text = "$"+items[tag].price.ToString();
                rect.sizeDelta = new Vector2(items[tag].width, (int)rect.sizeDelta.y);
                item.GetComponentInParent<Button>().interactable = true;
            }
        }
    }

    public void resetScene()
    {
        logic.firstGame = false;
        logic.gameOn = true;
        logic.dead = false;
        foreach (GameObject pipe in GameObject.FindGameObjectsWithTag("Pipe")){
            if (pipe.transform.rotation == new Quaternion(0, 0, 90, 0)) continue;
            Destroy(pipe);
        }
        foreach (GameObject middle in GameObject.FindGameObjectsWithTag("Middle"))
        {
            Destroy(middle);
        }
        foreach (GameObject coin in GameObject.FindGameObjectsWithTag("Coin")){
            Destroy(coin);
        }
        menu.SetActive(false);
        spawner.SetActive(true);
        int i = 1;
        foreach (GameObject bird in birds)
        {
            bird.SetActive(true);
            bird.transform.position = new Vector3(i*10, 0, 0);
            bird.transform.rotation = Quaternion.identity;
            bird.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            bird.GetComponent<Rigidbody2D>().angularVelocity = 0;
            bird.GetComponent<Bird_Script>().timerOn = false;
            i = -1;
        }
        logic.init();
        logic.playerScore = 0;
    }

    public void shopMenu()
    {
        shop.SetActive(true);
        updateItems();
        menu.SetActive(false);
    }

    public void Menu()
    {
        menu.SetActive(true);
        shop.SetActive(false);
        logic.getScore();
    }

    public void CheckFunds(GameObject item)
    {
        Text text = item.GetComponent<Text>();
        int price = int.Parse(text.text.TrimStart('$'));
        if (PlayerPrefs.GetInt("CoinCount") >= price)
        {
            PlayerPrefs.SetInt(item.tag, 1);
            logic.addMoney(-price);
            updateItems();
       
        foreach (GameObject bird in birds)
            bird.GetComponent<Bird_Script>().UpdateSprite();
        }
    }

    public void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
        logic.init();
        logic.getScore();
        foreach (GameObject bird in birds)
            bird.GetComponent<Bird_Script>().UpdateSprite();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public struct item
    {
        public int width;
        public int price;

        public item(int w, int p)
        {
            width = w;
            price = p;
        }
    }

    
}
