using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour {
    [SerializeField]
    private GameObject gun;
    public float RotationSpeed = 5;
    public float maxHorAngle = 20;
    private float maxHorizontal = 314;
    private float minHorizontal = 230;
    private float maxVertical = 14;
    private float minVertical = 0;
    

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        float y = gun.transform.localRotation.eulerAngles.y;
        float x = gun.transform.localRotation.eulerAngles.x;
        
        if (y < maxHorizontal && y > minHorizontal){
            transform.Rotate(Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime*-12, Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime*60, 0, Space.World);
        }else if(y > maxHorizontal){
            if (Input.GetAxis("Mouse Y") < 0) {
                transform.Rotate(Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime*-12, Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime*60, 0, Space.World);
            }
        }else if (y < maxHorizontal){
            if (Input.GetAxis("Mouse Y") > 0) {
                transform.Rotate(Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime*-12, Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime*60, 0, Space.World);
            }
        }

            
    }
}
