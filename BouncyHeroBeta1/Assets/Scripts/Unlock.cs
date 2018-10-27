using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock : MonoBehaviour
{
    public Button[] unlockButton=new Button[7];
    private int unlockIndex;

    private CharacterS CharacterSScript;
    private GameObject CharacterObject;

    public UIManager UIManagerScript;
    public GameObject UIObject;




    // Use this for initialization
    void Start ()
    {

        UIObject = GameObject.Find("UIManager");
        UIManagerScript = UIObject.GetComponent<UIManager>();

        unlockIndex =PlayerPrefs.GetInt("CharacterSelected");

        //call CharacterS script
        CharacterObject = GameObject.Find("CharacterS");
        if (CharacterSScript != null) CharacterSScript = CharacterObject.GetComponent<CharacterS>();

        //unlockIndex = CharacterSScript.index;


        //make the unseleted buttons invisible
        foreach (Button button in unlockButton)
        {
            button.gameObject.SetActive(false);

        }

        //make the selected button visible
        if (unlockButton[unlockIndex])
        {
           
                unlockButton[unlockIndex].gameObject.SetActive(true);

           

        }

        //unlockButton[unlockIndex].gameObject.SetActive(false);


       


    }

    // Update is called once per frame
    void Update ()
    {
        //checking if the heros are unlocked

        if (UIManagerScript.UnlockHeroInvisible1=true)
        {
            unlockButton[0].gameObject.SetActive(false);
        }

        if (UIManagerScript.UnlockHeros2)
        {
            unlockButton[1].gameObject.SetActive(false);
        }
        if (UIManagerScript.UnlockHeros3)
        {
            unlockButton[2].gameObject.SetActive(false);
        }
        if (UIManagerScript.UnlockHeros4)
        {
            unlockButton[3].gameObject.SetActive(false);
        }
        if (UIManagerScript.UnlockHeros5)
        {
            unlockButton[4].gameObject.SetActive(false);
        }
        if (UIManagerScript.UnlockHeros6)
        {
            unlockButton[5].gameObject.SetActive(false);
        }
        if (UIManagerScript.UnlockHeros7)
        {
            unlockButton[6].gameObject.SetActive(false);
        }

    }



    public void Left()
    {
        unlockButton[unlockIndex].gameObject.SetActive(false);
        unlockIndex -= 1;
        if (unlockIndex < 0)
        {
            unlockIndex = unlockButton.Length - 1;
        }


        unlockButton[unlockIndex].gameObject.SetActive(true);


        //if (unlockButton[0])
        //{
        //    unlockButton[unlockIndex].gameObject.SetActive(true);

        //}

        //if (unlockButton[1] && UIManagerScript.UnlockHeros2)
        //{
        //    unlockButton[unlockIndex].gameObject.SetActive(true);

        //}

        //if (unlockButton[2] && UIManagerScript.UnlockHeros3)
        //{
        //    unlockButton[unlockIndex].gameObject.SetActive(true);

        //}

        //if (unlockButton[3] && UIManagerScript.UnlockHeros4)
        //{
        //    unlockButton[unlockIndex].gameObject.SetActive(true);

        //}

        //if (unlockButton[4] && UIManagerScript.UnlockHeros5)
        //{
        //    unlockButton[unlockIndex].gameObject.SetActive(true);

        //}

        //if (unlockButton[5] && UIManagerScript.UnlockHeros6)
        //{
        //    unlockButton[unlockIndex].gameObject.SetActive(true);

        //}

        //if (unlockButton[6] && UIManagerScript.UnlockHeros7)
        //{
        //    unlockButton[unlockIndex].gameObject.SetActive(true);

        //}





    }


    public void Right()
    {
        unlockButton[unlockIndex].gameObject.SetActive(false);
        unlockIndex += 1;
        if (unlockIndex == unlockButton.Length)
        {
            unlockIndex = 0;
        }


        unlockButton[unlockIndex].gameObject.SetActive(true);







    }
}
