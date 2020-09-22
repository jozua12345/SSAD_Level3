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

    public int height;
    public int width;
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
    public GameObject levelScript;
    public GameObject gridController;

    private Animator boxAnimator;
    private AudioSource score;
    private AudioSource deflect;

    void Awake() {
        // correct or wrong
        status = false;
        // clicked or unclicked
        clicked = false;
    
        timeStart = 0;
        timeEnd = 1000;
        rendered = false;

        AudioSource[] sound = GetComponents<AudioSource>();
        score = sound[1];
        deflect = sound[0];


    }
    
    // Start is called before the first frame update
    void Start() {
        intervalX = gridWidth/width;
        intervalY = gridHeight/height;
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
        LevelScript levelScriptComponent = levelScript.GetComponentInChildren<LevelScript>();
        GridController gridControllerComponent = gridController.GetComponentInChildren<GridController>();

        if(rendered) {
            if (string.Equals(levelScriptComponent.curBulletColor, type)){
                levelScriptComponent.curScore += 2;
                gridControllerComponent.numberOfAliensLeft--;
                score.Play();
                animateDestroy();
            }else{
                levelScriptComponent.lives--;
                gridControllerComponent.correct = false;
                deflect.Play();
            }
            Debug.Log("Lives: " + levelScriptComponent.lives + " Score: " + levelScriptComponent.curScore);
        }
    }

    public void animateDestroy() {
        boxAnimator = myObj.GetComponent<Animator>();
        boxAnimator.Play("DestroyBox");
        Destroy(gameObject, boxAnimator.GetCurrentAnimatorStateInfo(0).length-0.3f); 
    }

}
