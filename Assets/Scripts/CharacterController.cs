using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    /*For animation*/
    public enum Face {
        UP,
        LEFT,
        RIGHT,
        DOWN,
    }

    public Face face;

	// Use this for initialization
	void Start () {
        face = Face.RIGHT;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W)) { //Move up
            face = Face.UP;
        } else if (Input.GetKeyDown(KeyCode.S)) { //Move down
            face = Face.DOWN;
        } else if (Input.GetKeyDown(KeyCode.A)) { //Move left
            face = Face.LEFT;
        } else if (Input.GetKeyDown(KeyCode.D)) { //Move right
            face = Face.RIGHT;
        }
	}
}
