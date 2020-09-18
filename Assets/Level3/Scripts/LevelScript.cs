using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    int gridSize = 4;
    public GridController gridController;
    int totalPoints;
    int target;
    int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkSolution();
        
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

            }

        }




    //go to next level
    }


    void generateGrid() {
        gridController = new GridController(gridSize);

    }

    void reloadBullet() {
    }

}