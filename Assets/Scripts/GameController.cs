using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance = null;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }


	
	// Update is called once per frame
	void Update () {
		
	}
}
