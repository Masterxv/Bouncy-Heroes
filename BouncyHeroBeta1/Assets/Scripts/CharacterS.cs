using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
//using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CharacterS : MonoBehaviour {
    public GameObject[] CharacterList;
    public int index;
    public UIManager UIManagerScript;
    public GameObject UIObject;

    //public Unlock UnlockScript;
    //public GameObject UnlockObject;





    // Use this for initialization
    void Start ()

    {


        UIObject = GameObject.Find("UIManager");
        UIManagerScript = UIObject.GetComponent<UIManager>();

        //UnlockObject = GameObject.Find("Unlock");
        //UnlockScript = UnlockObject.GetComponent<Unlock>();



        //totol number of heros
        index = PlayerPrefs.GetInt("CharacterSelected");
        CharacterList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {

            CharacterList[i] = transform.GetChild(i).gameObject;

        }

        foreach (GameObject character in CharacterList)
        {
            character.SetActive(false);
           

        }

        if (CharacterList[index])
        {
            CharacterList[index].SetActive(true);
        }



    }



    void Update()
    {
      
        firstHero();
        SecondHero();
        ThirdHero();
        FourthHero();
        FifthHero();
        SixthHero();
        SeventhHero();
       
    }


    void firstHero()
    {
        //default choosing hero setting
        if (index == 0)//the free hero
        {
           
            UIManagerScript.PriceTagImage.gameObject.SetActive(false);
            UIManagerScript.PriceTagText.gameObject.SetActive(false);
            UIManagerScript.selete.gameObject.SetActive(true);

            
            //make unlock button invisible
            //UnlockScript.unlockButton[0].gameObject.SetActive(false);

        }
    }

    void SecondHero()
    {
        if (index == 1)//heros can be purchased
        {
           
            UIManagerScript.PriceTagImage.gameObject.SetActive(true);
            UIManagerScript.PriceTagText.gameObject.SetActive(true);
            UIManagerScript.selete.gameObject.SetActive(false);



            if (UIManagerScript.UnlockHeros2)
            {
              

                UIManagerScript.PriceTagImage.gameObject.SetActive(false);
                UIManagerScript.PriceTagText.gameObject.SetActive(false);
                UIManagerScript.selete.gameObject.SetActive(true);



            }




        }
    }

   

    void ThirdHero()
    {
        if (index == 2)//heros can be purchased
        {
           
            UIManagerScript.PriceTagImage.gameObject.SetActive(true);
            UIManagerScript.PriceTagText.gameObject.SetActive(true);
            UIManagerScript.selete.gameObject.SetActive(false);

            if (UIManagerScript.UnlockHeros3)
            {


                UIManagerScript.PriceTagImage.gameObject.SetActive(false);
                UIManagerScript.PriceTagText.gameObject.SetActive(false);
                UIManagerScript.selete.gameObject.SetActive(true);


            }

        }
    }

    void FourthHero()
    {
        if (index == 3)//heros can be purchased
        {
         
            UIManagerScript.PriceTagImage.gameObject.SetActive(true);
            UIManagerScript.PriceTagText.gameObject.SetActive(true);
            UIManagerScript.selete.gameObject.SetActive(false);


            if (UIManagerScript.UnlockHeros4)
            {


                UIManagerScript.PriceTagImage.gameObject.SetActive(false);
                UIManagerScript.PriceTagText.gameObject.SetActive(false);
                UIManagerScript.selete.gameObject.SetActive(true);



            }
        }
    }

    void FifthHero()
    {

        if (index == 4)//heros can be purchased
        {
           
            UIManagerScript.PriceTagImage.gameObject.SetActive(true);
            UIManagerScript.PriceTagText.gameObject.SetActive(true);
            UIManagerScript.selete.gameObject.SetActive(false);

            if (UIManagerScript.UnlockHeros5)
            {
                
                UIManagerScript.PriceTagImage.gameObject.SetActive(false);
                UIManagerScript.PriceTagText.gameObject.SetActive(false);
                UIManagerScript.selete.gameObject.SetActive(true);


            }

        }
    }

    void SixthHero()
    {
        if (index == 5)//heros can be purchased
        {
           
            UIManagerScript.PriceTagImage.gameObject.SetActive(true);
            UIManagerScript.PriceTagText.gameObject.SetActive(true);
            UIManagerScript.selete.gameObject.SetActive(false);

            if (UIManagerScript.UnlockHeros6)
            {


                UIManagerScript.PriceTagImage.gameObject.SetActive(false);
                UIManagerScript.PriceTagText.gameObject.SetActive(false);
                UIManagerScript.selete.gameObject.SetActive(true);


            }

        }
    }

    void SeventhHero()
    {
        if (index == 6)//the free hero
        {
          
            UIManagerScript.PriceTagImage.gameObject.SetActive(true);
            UIManagerScript.PriceTagText.gameObject.SetActive(true);
            UIManagerScript.selete.gameObject.SetActive(false);

            if (UIManagerScript.UnlockHeros7)
            {
                
                UIManagerScript.PriceTagImage.gameObject.SetActive(false);
                UIManagerScript.PriceTagText.gameObject.SetActive(false);
                UIManagerScript.selete.gameObject.SetActive(true);


            }

        }
    }



    public void Left()
    {
        CharacterList[index].SetActive(false);
        index -= 1;
        if (index < 0)
        {
            index = CharacterList.Length - 1;
        }

            
            CharacterList[index].SetActive(true);

        


    }


    public void Right()
    {
        CharacterList[index].SetActive(false);
        index += 1;
        if (index == CharacterList.Length)
        {
            index = 0;
        }

       
        CharacterList[index].SetActive(true);

       

    }



    public void instantiateCharacter()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);

        //the defaulr hero
        if(index==0)
        {
            SceneManager.LoadScene("Level1");
           

        }
        

        //the purchased heros
        if (UIManagerScript.UnlockHeros2)
        {

            SceneManager.LoadScene("Level1");

        }

        if (UIManagerScript.UnlockHeros3)
        {
            SceneManager.LoadScene("Level1");
   

        }
        if (UIManagerScript.UnlockHeros4)
        {
            SceneManager.LoadScene("Level1");
        

        }
        if (UIManagerScript.UnlockHeros5)
        {
            SceneManager.LoadScene("Level1");
        
        }
        if (UIManagerScript.UnlockHeros6)
        {
            SceneManager.LoadScene("Level1");
            

        }
        if (UIManagerScript.UnlockHeros7)
        {
            SceneManager.LoadScene("Level1");
          

        }

    }
}
