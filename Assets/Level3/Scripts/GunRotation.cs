using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour {
    [SerializeField]
    private GameObject gun;
    public float RotationSpeed = 5;
    public float maxHorAngle = 20;
    

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
            transform.Rotate(Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime*-12, Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime*60, 0, Space.World);
    }
}
