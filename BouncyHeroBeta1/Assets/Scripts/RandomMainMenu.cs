using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomMainMenu : MonoBehaviour
{

    public Image randomImage;
    public Sprite s0;
    public Sprite s1;
    public Sprite s2;
    //public Sprite s3;
    public Sprite[] images;

    void Start()
    {
        images = new Sprite[4];
        images[0] = s0;
        images[1] = s1;
        images[2] = s2;
        //images[3] = s3;
    }

    void changeImage()
    {
        int num = UnityEngine.Random.Range(0, images.Length);
        randomImage.sprite = images[num];
    }




}
