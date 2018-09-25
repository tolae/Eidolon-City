using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    /*Player Fields*/
    float health; //The number of hitpoints a player can take before death
    float speed;  //How fast the player moves

	// Use this for initialization
	void Start () {
        health = 5;
        speed = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
