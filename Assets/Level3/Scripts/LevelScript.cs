using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    int[] gridSizes;
    int stage;
    public GridController gridController;
    int totalPoints;
    int target;
    bool gamePaused;
    bool renderGrid;

    public int lives;
    public string curBulletColor;
    public int curScore;
    public int maxScore;
    System.Random r;

    // Start is called before the first frame update
    void Start() {
        r = new System.Random();
        gridSizes = new int[] {0, 4, 5, 6};
        stage = 1;
        totalPoints = 76;
        lives = 3;
        gamePaused = false;
        renderGrid = true;
        reloadBullet();
        curScore = 0;
        maxScore = 60;
    }

    // Update is called once per frame
    void Update() {
        if (!gamePaused) {
            if(renderGrid) {
                gridController.setAndStartGrid(gridSizes[stage]);
                renderGrid = false;
            }else {
                if (lives <= 0){
                    Debug.Log("Game Over, you lose!");
                    Invoke("loadGameOver", 0.5f);
                }else if (curScore >= maxScore) {
                    Debug.Log("Game Over, you win!");
                }else {
                    if(gridController.checkSolution() == 1){
                        gridController.destroyAll();
                        stage++;
                        gridController.setAndStartGrid(gridSizes[stage]);
                        reloadBullet();
                    }else if (gridController.checkSolution() == 0){
                        gridController.destroyAll();
                        gridController.setAndStartGrid(gridSizes[stage]);
                        reloadBullet();
                    }
                }
            }
        }
    }

    void loadGameOver () {
        SceneManager.LoadScene("GameOver");
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
        string[] types = new string[] {"G", "R"};
        curBulletColor = types[r.Next(0, 2)];
        Debug.Log("Bullet color is now " + curBulletColor);
    }

}