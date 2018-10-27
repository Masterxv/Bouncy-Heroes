using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class SwipeHandler : MonoBehaviour
{

    public GameObject Player;
    //public UIManager UI;


    //the starting time in which the users swipe.
    public float startTime;

    //the end time in which users's fingers lift from screem.
    public float endTime;

    //The position of users' fingers.
    public Vector3 startPos;

    public Vector3 endPos;


    //the maximum time in which users swiping can be detected.
    //public float maxTime = 1 / Time.deltaTime / 3f;
    public float maxTime = 0.5f;

    //the minimum distance in which users swiping can be detected.
    public float minSwipeDis = (new Vector3(0.5f, 0.5f, 0)).magnitude;


    public float swipeDistance;

    public float swipeTime;

    public static bool swipeOrNot;

    private float timer = 3f;

    


    // Use this for initialization
    void Start()
    {
        swipeOrNot = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (DelayStart() <= 0)
        {

            if (Input.touchCount > 0)
            {

                Touch touch = Input.GetTouch(0);


                if (touch.phase == TouchPhase.Began
                ) //the starting time in whcih users just put their fingers on the screen.
                {
                    startTime = Time.time;
                    startPos = touch.position;
                }


                else if (touch.phase == TouchPhase.Ended) //the end time in which users lift fingers from the screen.
                {
                    endTime = Time.time;
                    endPos = touch.position;


                    swipeDistance = (endPos - startPos).magnitude;

                    swipeTime = endTime - startTime;


                    if (swipeTime < maxTime && swipeDistance > minSwipeDis) // users swiping can be detected.
                    {

                        Swipe();
                    }
                }
            }
        }





    }





    float DelayStart()
    {
        timer -= Time.deltaTime;
        return timer;
    }




    public void Swipe()
    {

        Vector2 distance = endPos - startPos;

        //compare the absolute value of x and y axis to check if users swipe horizontally.
        if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
          

            //compare the value of x axis with 0 to check if users swipe left ot right.
            if (distance.x > 0)
            {
                Debug.Log("Right Swipe");
                Player.GetComponent<PlayerMove>().JumpRight();
                

            }
            if (distance.x < 0)
            {
                Debug.Log("Left Swipe");
                Player.GetComponent<PlayerMove>().JumpLeft();
            }

            swipeOrNot = true;
        }

        //compare the absolute value of x and y axis to check if users swipe vertically.
        if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
        {
         
            //compare the value of y axis with 0 to check if users swipe up.
            if (distance.y > 0)
            {
                Debug.Log("Up Swipe");

                Player.GetComponent<PlayerMove>().Jump();
            }

            swipeOrNot = true;
        }

    }

    

}

