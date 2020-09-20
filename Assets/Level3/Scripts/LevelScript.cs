using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    int[] gridSizes;
    int stage;
    public GridController gridController;
    int totalPoints;
    int target;
    int lives;
    bool gamePaused;
    bool renderGrid;

    // Start is called before the first frame update
    void Start() {
        gridSizes = new int[] {0, 4, 5, 6};
        stage = 1;
        totalPoints = 76;
        lives = 3;
        gamePaused = false;
        renderGrid = true;
    }

    // Update is called once per frame
    void Update() {
        if(renderGrid) {
            gridController.setAndStartGrid(gridSizes[stage]);
            renderGrid = false;
        }
    }

    /*
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
    */


    void generateGrid() {
        //gridController = new GridController(gridSize);

    }

    void reloadBullet() {
    }

}