using System.Collections;
using System.Collections.Generic;
//using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
	public List<GameObject> background;

	public float shiftSpeed =0.5f;
	public float yPos = 9.5f;
	public float yLimit = 19f;
	private GameObject[] backGrounds = new GameObject[2];
	private int randomBcakground = 0;

	public float scaleY;
	public float scaleX;
	public float height;
	public float width;

	

	public float bgWidth;


	// Use this for initialization
	void Start ()
	{
		Initial ();

	}



	void Initial(){
		CreateNewbackground ();
		Duplicatebackground ();
	}


	// Update is called once per frame
	void Update()
	{
		Shift();
	}



	void CreateNewbackground()
	{
		List<GameObject> select = new List<GameObject> ();
		randomBcakground = Random.Range (0, background.Count);//ramdonly return an integer from a range;
		Debug.Log ("randomBcakground"); 


		GameObject newBackground = Instantiate (background [randomBcakground], new Vector3(0, 0, 0), Quaternion.identity);


		if (!select.Contains(background[randomBcakground]))
		{
			select.Add (newBackground); // add new background to the end of the list;
		}

		Renderer rd = newBackground.GetComponentInChildren<Renderer>();// applying the script to all children

		height = 2f * Camera.main.orthographicSize;
		width = height * Camera.main.aspect;

		bgWidth = width;

		scaleX = width/(rd.bounds.size.x*2 )- newBackground.transform.localScale.x +0.1f;
		scaleY = (height*2) / (rd.bounds.size.y * 2) - newBackground.transform.localScale.y+0.03f;
		newBackground.transform.localScale += new Vector3(scaleX, scaleY, 0);

	   
		
		backGrounds[0] = newBackground;
	}





	void Duplicatebackground(){
		List<GameObject> select = new List<GameObject> ();

		Vector3 pos = new Vector3 (0, 20f, 0);
		GameObject bg = Instantiate (background [randomBcakground], pos, Quaternion.identity);
		if(!select.Contains(background[randomBcakground])){
			select.Add (bg);
		}
		bg.transform.localScale += new Vector3(scaleX, scaleY, 0);
		backGrounds[1] = bg;
	}


	void Shift(){
		for(int i=0; i< backGrounds.Length; i++){
			backGrounds [i].transform.position += -Vector3.down * shiftSpeed * Time.deltaTime;
			CheckDisposeObject (backGrounds [i], i);
		}
	}

	void CheckDisposeObject(GameObject bg, int i){
		if (bg.transform.position.y < Camera.main.transform.position.y - yLimit)
		{
			int belowBg=0;
			if (i == 0)
			{
				belowBg = 1;
			}
			bg.transform.position = new Vector3(0, backGrounds[belowBg].transform.position.y + yPos, 0);
		}
	}

	

}
