using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    
    private UIManager UIScript;
    private GameObject UIObject;
    private Rigidbody2D rb;

    private PlayerMove PlayerMoveScript;
    private GameObject PlayerMoveObject;


    void Start()
    {
        //instantiate the UIManager class
        UIObject = GameObject.Find("UIManager");
        UIScript = UIObject.GetComponent<UIManager>();

        if (PlayerMoveScript != null)
        {
            PlayerMoveObject = GameObject.Find("PlayerMove");
            PlayerMoveScript = PlayerMoveObject.GetComponent<PlayerMove>();
        }
      

        rb = GetComponent<Rigidbody2D>();

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player" )
        {
            Destroy(rb);
            Destroy(col.gameObject);
            UIScript.GameOverActivated();
            UIScript.gameOver = true;

            if (PlayerMoveScript != null)
            {
                PlayerMoveScript.gameOver = true;
            }


        }

        
    }


}
