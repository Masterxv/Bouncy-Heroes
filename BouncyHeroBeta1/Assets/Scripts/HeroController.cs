using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {
	public List<GameObject> hero;
	public GameObject SelectedHero;
	
	
	
	// Use this for initialization
	void Start ()
	{
		CreateNewHero();


	}
	


	void CreateNewHero ()
	{

		List<GameObject> select= new List<GameObject>();
		
		int number= PlayerPrefs.GetInt("CharacterSelected");
	
			if (!select.Contains(hero[number]))
			{
				SelectedHero = (GameObject) Instantiate(hero[number], this.transform.position, Quaternion.identity);
				select.Add(SelectedHero);
			}
	   

	}


}
