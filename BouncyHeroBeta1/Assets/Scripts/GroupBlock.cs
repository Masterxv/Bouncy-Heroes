using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupBlock : MonoBehaviour {

	public List<GameObject> GroupOfBlocks;

	//public float shiftSpeed =2f;
	public float yPos = 9.5f;
	public int score;
	public int phase1=0;
	public int phase2=32;
	public int phase3=64;
	public int phase4=1000;
	public static bool phaseOne=false;
	public static bool phaseTwo = false;
	public static bool phaseThree = false;
	public static bool phaseFour = false;
	public float scaleWidth;


	private GameObject currentblock;
	private GameObject nextblock;
	private int randomBlock;

	void Start()
	{
		score = 0;
		FirstBlock();
	}

	// Update is called once per fame
	void Update()
	{
		score = UIManager.score;
		randomBlock = phaseController();
		phaseController();


		if (nextblock != null)
		{

			if (nextblock.transform.position.y <= Camera.main.transform.position.y)
			{
				Newblock();

			}


		}


	}




	void FirstBlock()
	{
		List<GameObject> list = new List<GameObject>();
		randomBlock = phaseController();
		Debug.Log("RandomBlock");
		currentblock = Instantiate(GroupOfBlocks[randomBlock], new Vector3(0, 3f, 0), Quaternion.identity) as GameObject;
		float screenWidth = (2f * Camera.main.orthographicSize) * Camera.main.aspect;
		scaleWidth = screenWidth/6.6f;

		if (!list.Contains(GroupOfBlocks[randomBlock]))
		{
			list.Add(currentblock);
		}
		currentblock.transform.localScale = new Vector3(scaleWidth, scaleWidth, 0);
		currentblock.transform.position = new Vector3(0, 3f*scaleWidth, 0);
		nextblock = Instantiate(GroupOfBlocks[randomBlock], new Vector3(0, currentblock.transform.position.y + yPos*scaleWidth, 0), Quaternion.identity) as GameObject;
		//nextblock.transform.SetParent(currentblock.transform);

		nextblock.transform.localScale = new Vector3(scaleWidth, scaleWidth, 0);
	}




	void Newblock()
	{
		List<GameObject> list = new List<GameObject>();
		nextblock.transform.SetParent(null);
		Destroy(currentblock);
		currentblock = nextblock;
		randomBlock = phaseController();
		nextblock = Instantiate(GroupOfBlocks[randomBlock], new Vector3(0, currentblock.transform.position.y + yPos*scaleWidth, 0), Quaternion.identity) as GameObject;
		//nextblock.transform.SetParent(currentblock.transform);

		if (!list.Contains(GroupOfBlocks[randomBlock]))
		{
			list.Add(nextblock);

		}
		nextblock.transform.localScale = new Vector3(scaleWidth, scaleWidth, 0);

	}




	int phaseController()
	{


		if (score >= phase1 && score <= phase2)
		{
			randomBlock = Random.Range(0, 4);
			//GroupOfBlocks[randomBlock]
			Debug.Log("phase1");

			//hint for changing speed according to different phases
			phaseOne = true;
		}
		else if (score > phase2 && score <= phase3)
		{

			randomBlock = Random.Range(5, 9);
			Debug.Log("phase2");

			//hint for changing speed according to different phases
			phaseTwo = true;
			phaseOne = false;

		}
		else if (score > phase3 && score<=phase4)
		{

			//need to increase;
			randomBlock = Random.Range(10, 19);
			Debug.Log("phase3");

			//hint for changing speed according to different phases
			phaseThree = true;
			phaseTwo = false;
			phaseOne = false;
		}

		return randomBlock;

	}




}