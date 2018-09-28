﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class holds all the information for the Player.
 */
public class Player : MonoBehaviour {

    /*Player Fields*/
    [SerializeField] private float health = 5; //The number of hitpoints a player can take before death
    [SerializeField] private float speed = 10;  //How fast the player moves
    [SerializeField] private float jumpSpeed = 15; //How fast the player moves while jumping
    private Vector2 movement = new Vector2(); //The directional of where the player wants to move
    private bool jump = false; //If the character hit to jump or not

    public MyCharacterController controller; //Tells the Player what to do when things happen
    public Animator animator; //Selects which animation to be playing at what time

	// Use this for initialization
	void Start () {
        health = 5;
        speed = 10;
	}

    private void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (!jump)
            jump = Input.GetKeyDown(KeyCode.Space);

        animator.SetFloat("Speed", movement.magnitude);

        movement *= speed;
    }

    private void FixedUpdate() {
        StartCoroutine(controller.Move(movement, jump));
    }

    public void OnJump(bool isJumping) {
        if (isJumping)
            animator.SetTrigger("Jumping");
        else
            jump = false;
    }

    public void OnClick() {
        if (!jump)
            Debug.Log("Shooting");
    }
}
