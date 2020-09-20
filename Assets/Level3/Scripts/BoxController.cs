using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {
    Transform transform;

    //public Alien alien;
    // correct or wrong
    public bool status;
    // clicked or unclicked
    public bool clicked;
    public Wall wall;
    public int row;
    public int col;

    public int gridSize;
    public float gridHeight;
    public float gridWidth;
    public float intervalX;
    public float intervalY;
    public float startX;

    public float maxY;
    public float curY;
    public int timeStart;
    public int timeEnd;
    public bool rendered;
    public string type;

    public GameObject myObj;

    void Awake() {
        // correct or wrong
        status = false;
        // clicked or unclicked
        clicked = false;
    
        timeStart = 0;
        timeEnd = 1000;
        rendered = false;

    }
    
    // Start is called before the first frame update
    void Start() {
        intervalX = gridWidth/gridSize;
        intervalY = gridHeight/gridSize;
        maxY = row*intervalY;
        //createAlien();
        transform = GetComponent<Transform>();
        //wall = GameObject.transform.GetChild(2).transform.GetComponent<Wall>();
        wall = myObj.GetComponentInChildren<Wall>();
        
        transform.localPosition = new Vector3(startX+col*intervalX, curY, 20f);
        
    }

    // Update is called once per frame
    void Update() {
        // Start animaton
        if (curY < maxY) {
            transform.localPosition += new Vector3(0f,0.05f,0f);
            curY += 0.05f;
        }else{
            if(!rendered) {
                if(timeStart > timeEnd){
                    wall.render();
                }
                rendered = wall.getRendered();
            }
            timeStart++;
        }
        

    }

    public BoxController(int row, int col, int gridSize) {

    }

    /*
    public void createAlien() {
        this.alien = new Alien();
    }

    public void killAlien() {
        this.alien = null;
    }

    public string getAlienStatus() {
        return this.alien.getType();
    }*/

    public bool getBoxStatus() {
        return this.status;
    }

    public bool isBoxClicked() {
        return this.clicked;
    }

    public void setBoxStatus(bool status) {
        this.status = status;
    }

    public void setBoxClicked(bool clicked) {
        this.clicked = clicked;
    }

    public void randomizeAlien() {
        //this.alien.randomizeType();
    }

    void OnMouseDown() {
        if(rendered) {
            Destroy(gameObject);
        }
    }

}
