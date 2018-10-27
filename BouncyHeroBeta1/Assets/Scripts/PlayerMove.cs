using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public GameObject dust;

	public float jumpForce = 2f;
	public float jumpDistance = 2f;
	public float jumpSpeed = 25f;

	private UIManager UIScript;
	private GameObject UIObject;
	private Vector3 dis;
	public Vector3 target;
	private Rigidbody2D rb;
	private bool start;
	public static bool canJump;
	public bool gameOver;
	private bool side;
	public float sideJS;
	public float speed;

	private float rate;




	// Use this for initialization
	void Start()
	{

		gameOver = false;
		rb = GetComponent<Rigidbody2D>();
		UIObject = GameObject.Find("UIManager");
		UIScript = UIObject.GetComponent<UIManager>();
		side = false;
		sideJS = 0.9f;

		rate = GameObject.Find("BlockController").GetComponent<GroupBlock>().scaleWidth;

	}

	// Update is called once per frame
	void Update()
	{


		if (rb != null)
		{
			IsControllerGrounded();
		}


		if (gameOver == false)
		{



			if (start)
			{
				speed = jumpSpeed;
				if (side == true)
				{
					speed = speed*sideJS;
				}
				rb.gravityScale = 0;
				transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

			}
			if (transform.position == target)
			{
				start = false;
				rb.gravityScale = 1;

				UIManager.score += 1;

				//prevent the score from adding 1 point twice at one time
				target=new Vector3(0,0,0);


			}



		}




	}


	//to check if the game object touches ground before it can jump again.
	public void IsControllerGrounded()
	{
		if (rb != null)
		{

			if (rb.IsTouchingLayers())
			{

				canJump = true;



			}

			else
			{
				canJump = false;
				//Debug.Log("off ground");
			}






		}


	}



	public void Jump()
	{

		if (canJump)
		{

			side = false;
			target = new Vector3(transform.position.x, transform.position.y + (jumpForce * rate),-2);
			dis = target - transform.position;
			start=true;

			Debug.Log("Jump");

		}

	}



	public void JumpLeft()
	{
		if (canJump)
		{
			side = true;
			target = new Vector3(transform.position.x - (jumpDistance * rate)-0.1f, transform.position.y + (jumpForce * rate), -2);
			start = true;

			Debug.Log("Jump left");
		}
	}

	public void JumpRight()
	{
		if (canJump)
		{


			side = true;
			target = new Vector3(transform.position.x + (jumpDistance * rate) + 0.1f, transform.position.y + (jumpForce * rate), -2);
			start = true;

			Debug.Log("Jump right");

		}

	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "SafeGround"&& SwipeHandler.swipeOrNot==true)
		{


			dust.gameObject.SetActive(true);


		}
	}




}