using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyCount : MonoBehaviour {

	public Text readyText;
	public int readyCount = 3;

	// Use this for initialization
	void Start () {
		StartCoroutine("LoseTime");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (readyText != null)
		{
			readyText.text = readyCount.ToString();
			if (readyCount <= 0)
			{
				StopCoroutine("LoseTime");
				Destroy(readyText);


			}
		}
	}


	IEnumerator LoseTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			readyCount--;
		}
	}
}
