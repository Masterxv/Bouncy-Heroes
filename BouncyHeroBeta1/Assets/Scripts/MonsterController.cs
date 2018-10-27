using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{

	public List<GameObject> Lbullet;
	private GameObject bullet;
	private float HeroVSMonster;
	private GameObject Hero;
	private int RandomBullet = 0;
	private bool shoot;
	private float shootingTime;
	private float lastShoot;
	private float shootRate = 0.5f;
	private GameObject characterSelection;
	private int index;



	// Use this for initialization
	void Start ()
	{
		GameObject HeroController = GameObject.Find("HeroController");
		Hero = HeroController.GetComponent<HeroController>().SelectedHero;
		shoot = false;
		shootingTime = 0;
		lastShoot = -1;
	}
	

	// Update is called once per frame
	void Update ()
	{
		if(Hero!=null)HeroVSMonster = Hero.transform.position.y - gameObject.transform.position.y;
		if (HeroVSMonster < 0 && HeroVSMonster >= -3f)
		{
			shoot = true;
			shootingTime += Time.deltaTime;
			if (lastShoot == -1 || (shootingTime - lastShoot) >= shootRate)
			{
				GenerateBullet();
				lastShoot = shootingTime;
			}
		}
		else
		{
			shoot = false;
		}
	}


	void GenerateBullet()
	{
		RandomBullet = Random.Range(0, Lbullet.Count);
		bullet = Instantiate(Lbullet[RandomBullet],new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.18f, 0),
			Quaternion.identity);
		bullet.transform.SetParent(gameObject.transform);
	}
}
