using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameover;
    public GameObject gameOverPanel;
    public static int numberOfCoins;
    public Text CoinsText;
    public static bool isGameStarted;
    public GameObject startingText;

    
    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
        Time.timeScale = 1;
        numberOfCoins = 0;
        isGameStarted = false;




    }

    // Update is called once per frame
    void Update()
    {
        if(gameover)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        CoinsText.text = "Coins: " + numberOfCoins;

        if(SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startingText);
        }
        
    }
}
