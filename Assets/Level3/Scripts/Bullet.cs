using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Bullet : MonoBehaviour
{
    public Sprite greenBullet;
    public Sprite redBullet;
    Sprite bulletColor;
    // Start is called before the first frame update
    void Start()
    {
        setBulletColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setBulletColor() {
        Sprite[] arr = { greenBullet, redBullet };
        Random random = new Random();
        int index = random.Next(0, arr.Length);
        print("BULLET COLOR " + arr[index]);
        this.gameObject.GetComponent<Image>().sprite = arr[index];
    }
}
