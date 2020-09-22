using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelScript : MonoBehaviour
{
    int gridSize = 4;
    public GridController gridController;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public Image fuelMeter;
    float totalPoints;
    float target;
    static int lives = 3;
    public Image[] images;

    // Start is called before the first frame update
    void Start()
    {
        fuelMeter.fillAmount = 0;
        target = 72;
    }

    // Update is called once per frame
    void Update()
    {

        checkSolution();
        fillFuel();

    }

    void checkSolution(){  //check the points if it reach the target


        if(totalPoints < target) {
            totalPoints += gridController.getGridPoints();

            if (gridController.checkGridStatus())
            {
                
                gridSize += 1;
                generateGrid();
                reloadBullet();
                
            }
            else
            {

                if (lives == 0)
                {
                    Debug.Log("GAME OVER");
                    //SHOW GAME OVER SCREEN
                    return;
                }
                else
                {
                    lives--;
                    generateGrid();
                }
                showLives();

            }

        }




    //go to next level
    }

    public void fillFuel() {  //affect the fuel meter
        float points = totalPoints / target;
        fuelMeter.fillAmount = points;
    }

    public void setLives(){  //test function to see lives
        lives--;
        showLives();
    }

    void showLives()
    {

        switch (lives)
        {
            case 0:
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;
            case 1:
                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);

                break;

            case 2:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(false);

                break;
            case 3:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);

                break;

        }
    }

   


    void generateGrid() {
        gridController = new GridController(gridSize);

    }

    void reloadBullet() {
    }

}