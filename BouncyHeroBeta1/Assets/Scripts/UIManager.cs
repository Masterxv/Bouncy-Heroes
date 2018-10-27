using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Button replay;
    public Button mainMenu;
    public Button pause;
    public Button selete;
    public GameObject tutF;
    public GameObject tutL;
    public GameObject tutR;
    public GameObject tutText;
    public float tutTime;

    public Text scoreOnPlayText;
    public Text highestScoreText;
    public Text lastScore;
    public Text scoreTextGameOver;
    public Text coinText;
    public Image highScoreImage;
    public Image scoreImage;
    public Image PriceTagImage;
    public Text PriceTagText;
    public bool gameOver;
    public static int score;
 

    private int highScore;
    private int coin;
    private int balance;
    public bool UnlockHeroInvisible1;
    public bool UnlockHeros2;
    public bool UnlockHeros3;
    public bool UnlockHeros4;
    public bool UnlockHeros5;
    public bool UnlockHeros6;
    public bool UnlockHeros7;


    public CharacterS CharacterSScript;
    public GameObject CharacterObject;

    public Unlock UnlockScript;
    public GameObject UnlockObject;




    // Use this for initialization
    void Start()
    {
        //set the time as real time in game play modexs
        Time.timeScale = 1;


        UnlockObject = GameObject.Find("Unlock");
        if (UnlockScript != null)UnlockScript = UnlockObject.GetComponent<Unlock>();

        CharacterObject =GameObject.Find("CharacterS");
        if(CharacterSScript!=null) CharacterSScript = CharacterObject.GetComponent<CharacterS>();


        //game is not over by default
        gameOver = false;
        score = 0;


        UnlockHeroInvisible1 = true;

        if (PlayerPrefs.GetInt("Unlock2") == 2)
        {
            UnlockHeros2 = true;

            //hide unlock button
           

        }
        else
        {
            UnlockHeros2 = false;
            
            //show unlock button
           
        }

        if (PlayerPrefs.GetInt("Unlock3") == 3)
        { UnlockHeros3 = true; }
        else
        {
            UnlockHeros3 = false;
        }

        if (PlayerPrefs.GetInt("Unlock4") == 4)
        { UnlockHeros4 = true; }
        else
        {
            UnlockHeros4 = false;
        }

        if (PlayerPrefs.GetInt("Unlock5") == 5)
        { UnlockHeros5 = true; }
        else
        {
            UnlockHeros5 = false;
        }

        if (PlayerPrefs.GetInt("Unlock6") == 6)
        { UnlockHeros6 = true; }
        else
        {
            UnlockHeros6 = false;
        }

        if (PlayerPrefs.GetInt("Unlock7") == 7)
        { UnlockHeros7 = true; }
        else
        {
            UnlockHeros7 = false;
        }
        StartCoroutine(TurnOffTut());
    }

    //Turn off tutorial
    IEnumerator TurnOffTut()
    {
        yield return new WaitForSeconds(tutTime);
        tutF.SetActive(false);
        tutL.SetActive(false);
        tutR.SetActive(false);
        tutText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       

        //score shown in the play screen
        if (scoreOnPlayText != null) scoreOnPlayText.text = score.ToString();

        //score shown in the game over mode
        if (scoreTextGameOver != null) scoreTextGameOver.text = score.ToString();

        //store the last socre and show it in the high score screen
        if (lastScore != null) lastScore.text = PlayerPrefs.GetInt("lastScore", 0).ToString();

        //store the highest score after game is over and show it in the high score screen
        if (highestScoreText != null) highestScoreText.text = PlayerPrefs.GetInt("highScoreText", 0).ToString();

        
         coinText.text = PlayerPrefs.GetInt("Coin",0).ToString();


        //updating the game score
        ScoreAfterGameOver();

     



    }


    //set the highest score and last score
    public void ScoreAfterGameOver()
    {
        if (gameOver)
        {
           

            //the highest score
            if (score > PlayerPrefs.GetInt("highScoreText", 0))
            {
           
                PlayerPrefs.SetInt("highScoreText", score);

                
            }

            //the last socre
            if (score <= PlayerPrefs.GetInt("highScoreText", 0))
            {

                PlayerPrefs.SetInt("lastScore", score);

                
            }

        }


    }

  
    public void GameOverActivated()
    {
        //notify the other objects that the gameOverActivated is active
        gameOver = true;

        //show hidden buttons and texts
        replay.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(true);
        highestScoreText.gameObject.SetActive(true);
        scoreTextGameOver.gameObject.SetActive(true);
        highScoreImage.gameObject.SetActive(true);
        scoreImage.gameObject.SetActive(true);

        //hide pause button
        pause.gameObject.SetActive(false);

        //deactive the socre on game play
        scoreOnPlayText.gameObject.SetActive(false);


        //store coin when the socre is the highest
        coin = PlayerPrefs.GetInt("Coin", 0);
        coin += score;
        PlayerPrefs.SetInt("Coin", coin);
    }



    public void Unlock2()
    {
        balance = PlayerPrefs.GetInt("Coin");
        if (balance >= 1000)
        {
            balance -= 1000;
            PlayerPrefs.SetInt("Coin", balance);
            UnlockHeros2 = true;
            //use an integer to notify that the unlock hero is persistent
            PlayerPrefs.SetInt("Unlock2",2);

          
        }

    }

    public void Unlock3()
    {
        balance = PlayerPrefs.GetInt("Coin");
        if (balance >= 1000)
        {
            balance -= 1000;
            PlayerPrefs.SetInt("Coin", balance);
            UnlockHeros3 = true;
            PlayerPrefs.SetInt("Unlock3", 3);
        }

    }

    public void Unlock4()
    {
        balance = PlayerPrefs.GetInt("Coin");
        if (balance >= 1000)
        {
            balance -= 1000;
            PlayerPrefs.SetInt("Coin", balance);
            UnlockHeros4 = true;
            PlayerPrefs.SetInt("Unlock4", 4);
        }

    }

    public void Unlock5()
    {
        balance = PlayerPrefs.GetInt("Coin");
        if (balance >= 1000)
        {
            balance -= 1000;
            PlayerPrefs.SetInt("Coin", balance);
            UnlockHeros5 = true;
            PlayerPrefs.SetInt("Unlock5", 5);
        }

    }

    public void Unlock6()
    {
        balance = PlayerPrefs.GetInt("Coin");
        if (balance >= 1000)
        {
            balance -= 1000;
            PlayerPrefs.SetInt("Coin", balance);
            UnlockHeros6 = true;
            PlayerPrefs.SetInt("Unlock6", 6);
        }

    }

    public void Unlock7()
    {
        balance = PlayerPrefs.GetInt("Coin");
        if (balance >= 1000)
        {
            balance -= 1000;
            PlayerPrefs.SetInt("Coin", balance);
            UnlockHeros7 = true;
            PlayerPrefs.SetInt("Unlock7", 7);
        }

    }



    public void Reset()
    {
        PlayerPrefs.DeleteKey("highScoreText");
        PlayerPrefs.DeleteKey("lastScore");
        PlayerPrefs.DeleteKey("Coin");
        PlayerPrefs.DeleteKey("Unlock2");

        PlayerPrefs.DeleteAll();

        score = 0;
        if (highestScoreText != null) highestScoreText.text = "0";
        if (lastScore != null) lastScore.text = "0";
        
    }



    public void Play()
    {
        Application.LoadLevel("Level1");
    }

    public void Pause()
    {
        // if time is passing as real time
        if (Time.timeScale == 1)
        {
            //game is paused pause 
            Time.timeScale = 0;

            //show hidden buttons and texts
            replay.gameObject.SetActive(true);
            mainMenu.gameObject.SetActive(true);
            highestScoreText.gameObject.SetActive(true);
            highScoreImage.gameObject.SetActive(true);



        }

        //else if game is paused
        else if (Time.timeScale == 0)
        {
            //set the time is passed as real time
            Time.timeScale = 1;

            //hide buttons and texts
            replay.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(false);
            highestScoreText.gameObject.SetActive(false);
            highScoreImage.gameObject.SetActive(false);

        }


    }

    
    public void Mute()
    {

        AudioListener.pause = !AudioListener.pause;
    }


    public void Replay()
    {
        Application.LoadLevel("Level1");

        
    }

    public void Menu()
    {
        Application.LoadLevel("MenuScene");
    }

    public void Setting()
    {
        Application.LoadLevel("Setting");
    }


    public void HighestSocre()
    {
        Application.LoadLevel("HighestScore");
    }

    public void Hero()
    {
        Application.LoadLevel("Hero");
    }

    public void Credit()
    {
        Application.LoadLevel("Credit");
    }

   
    public void Exit()
    {
        Application.Quit();
    }




}


