using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject Hero;
    private float shiftSpeed = -1.5f;
    private Vector3 heroVSMonster;

    // Use this for initialization
    void Start()
    {
        Initial();
    }

    // Update is called once per fame
    void Update()
    {
        move();
    }


    void Initial()
    {

        GameObject HeroController = GameObject.Find("HeroController");
        Hero = HeroController.GetComponent<HeroController>().SelectedHero;
        if (heroVSMonster != null && Hero != null)
        {
            heroVSMonster = transform.parent.position - Hero.transform.position;
        }

        //Duplicateblock ();
    }


    void move()
    {
        transform.position += heroVSMonster * shiftSpeed * Time.deltaTime;
    }
    //void FirstBlock()
    //{
    //    List<GameObject> select = new List<GameObject>();
    //    RandomBullet = Random.Range(0, bullet.Count);

    //    Debug.Log("RandomBullet");
    //    curbullet = Instantiate(bullet[RandomBullet],
    //        new Vector3(Monster.transform.position.x, Monster.transform.position.y + 0.18f, 0),
    //        Quaternion.identity) as GameObject;

    //    if (!select.Contains(bullet[RandomBullet]))
    //    {
    //        select.Add(curbullet);
    //    }

    //    nextbullet = Instantiate(bullet[RandomBullet],
    //        new Vector3(Monster.transform.position.x, Monster.transform.position.y + 0.18f, 0),
    //        Quaternion.identity) as GameObject;
    //    nextbullet.transform.SetParent(curbullet.transform);

    //}

    //void newblock()
    //{
    //    List<GameObject> select = new List<GameObject>();
    //    nextbullet.transform.SetParent(null);
    //    Destroy(curbullet);
    //    RandomBullet = Random.Range(0, bullet.Count);
    //    curbullet = nextbullet;

    //    nextbullet = Instantiate(bullet[RandomBullet],
    //            new Vector3(Monster.transform.position.x, Monster.transform.position.y, 0), Quaternion.identity) as
    //        GameObject; //(0, curbullet.transform.position.y + yPos, 0)
    //    nextbullet.transform.SetParent(curbullet.transform);
    //    if (!select.Contains(bullet[RandomBullet]))
    //    {
    //        select.Add(nextbullet);
    //    }
    //}



    //float DelayStart()
    //{
    //    timer -= Time.deltaTime;
    //    return timer;
    //}


}
