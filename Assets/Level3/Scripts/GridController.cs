using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GridController : MonoBehaviour {
    private BoxController[,] grid;
    private GameObject[,] gridObject;
    private int size;
    private int gridHeight;
    private int gridWidth;
    public GameObject boxPrefab;
    public GameObject box2Prefab;
    private float startX;
    private float maxY;
    private float curY;
    string[] types;
    int[] typesArr;
    System.Random r;

    void Awake() {       
        gridHeight = 10;
        gridWidth = 40;
        startX = -15;
        curY = -3.6f;
        
        //setAndStartGrid(4);
    }

    public void setAndStartGrid(int size) {
        this.size = size;
        
        grid = new BoxController[size, size];
        gridObject = new GameObject[size, size];
        types = new string[] {"G", "R"};
        r = new System.Random();

        typesArr = new int[size*size];
        for (int j = 0; j < size*size; j++) {
            if (j < (size*size)/2){
                typesArr[j] = 0;
            }else{
                typesArr[j] = 1;
            }
        }
        typesArr = typesArr.OrderBy(x => r.Next()).ToArray();
        int index = 0;
        for (int row = 0; row < size; row++) {
            for (int col = 0; col < size; col++) {
                string type = types[typesArr[index]];
                index++;
                // Render prefab according to type
                GameObject a = null;
                if (type=="G"){
                    a = Instantiate(boxPrefab);
                }else if(type == "R"){
                    a = Instantiate(box2Prefab);
                }else{
                    a = Instantiate(boxPrefab);
                }
                gridObject[row, col] = a;
                grid[row, col] = a.GetComponent<BoxController>();
                grid[row, col].row = row;
                grid[row, col].col = col;
                grid[row, col].gridSize = size;
                grid[row, col].gridHeight = gridHeight;
                grid[row, col].gridWidth = gridWidth;
                grid[row, col].startX = startX;
                grid[row, col].curY =  curY;
                grid[row, col].myObj = a;
                grid[row, col].type = type;
            }
        }
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }

    /*
    public GridController(int size) {
        
        this.size = size;
        this.grid = new BoxController[size, size];

        for (int row = 0; row < size; row++) {
            for (int col = 0; col < size; col++) {
                grid[row, col] = Instantiate(boxPrefab).GetComponent<BoxController>();
                grid[row, col].row = row;
                grid[row, col].col = col;
                grid[row, col].gridSize = size;
                grid[row, col].gridHeight = gridHeight;
                grid[row, col].gridWidth = gridWidth;
                grid[row, col].startX = startX;
                grid[row, col].curY = curY;
            }
        }
        scrambleGrid();


        //show timer countdown 
        //rotate the box to hide aliens

    }

    public void scrambleGrid() {
        for (int row = 0; row < size; row++) {
            for (int col = 0; col < size; col++) {
                grid[row, col].randomizeAlien();
            }
        }
    }*/

    public BoxController[,] getGrid() {
        return grid;
    }

    public bool checkGridStatus() {
        bool ans = true;
        for (int row = 0; row < size; row++) {
            for (int col = 0; col < size; col++) {
                if(grid[row, col].isBoxClicked()) {
                    ans = ans && grid[row, col].getBoxStatus();
                }
            }
        }
        return ans;
    }

    public int getGridPoints() {
        return 0;  //0 first or the fuel meter will increase every update 
    }
}
    