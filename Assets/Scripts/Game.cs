using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public static SpaceShooterControls Input { get; private set; }  //initalize SpaceShooterControls as input

    // Start is called before the first frame update
    void Start() {
        Input = new SpaceShooterControls();     //grab input
        Input.Enable();                         //enable input assets

    }

    // Update is called once per frame
    void Update() {
        
    }
}
