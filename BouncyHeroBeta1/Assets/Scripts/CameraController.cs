using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float shiftSpeed=2f;

    private float timer=3f;

    private bool gameOver;

    private UIManager UIScript;

    private GameObject UIObject;


    // Use this for initialization
    void Start()
    {

        gameOver = false;

        UIObject = GameObject.Find("UIManager");
        UIScript = UIObject.GetComponent<UIManager>();

    }


    // Update is called once per frame
    void Update()
    {
        if (dealyStart() <= 0)
        {
            if(GroupBlock.phaseOne)this.transform.position += new Vector3(0, shiftSpeed * Time.deltaTime, 0);

            if(GroupBlock.phaseTwo)this.transform.position += new Vector3(0, (shiftSpeed+0.7f) * Time.deltaTime, 0);

            if(GroupBlock.phaseThree)this.transform.position += new Vector3(0, (shiftSpeed+0.7f) * Time.deltaTime, 0);
        }

        if (UIScript.gameOver==true)
        {
            GroupBlock.phaseOne=false;
            GroupBlock.phaseTwo = false;
            GroupBlock.phaseThree = false;

        }



        //if (dealyStart() <= 0)
        //{

        //    if (GroupBlock.phaseOne)
        //    {
        //        this.transform.position += new Vector3(0, shiftSpeed * Time.deltaTime, 0);

        //        if (GroupBlock.phaseTwo)
        //        {

        //            shiftSpeed += 1f;
        //            this.transform.position += new Vector3(0, shiftSpeed * Time.deltaTime, 0);

        //            if (GroupBlock.phaseThree)
        //            {
        //                shiftSpeed += 1f;
        //                this.transform.position += new Vector3(0, (shiftSpeed + 0.5f) * Time.deltaTime, 0);

        //                if (GroupBlock.phaseFour)
        //                {
        //                    shiftSpeed += 1f;
        //                    this.transform.position += new Vector3(0, (shiftSpeed + 0.5f) * Time.deltaTime, 0);
        //                }
        //            }
        //        }
        //    }




        //}




    }

    float dealyStart()
    {
        timer -= Time.deltaTime;

        return timer;
        
    }



    
}