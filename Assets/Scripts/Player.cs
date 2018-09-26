using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    /*Player Fields*/
    [SerializeField] private float health = 5; //The number of hitpoints a player can take before death
    [SerializeField] private float speed = 10;  //How fast the player moves
    [SerializeField] private float jumpSpeed = 15; //How fast the player moves while jumping
    private Vector2 movement; //The directional of where the player wants to move
    private bool jump; //If the character hit to jump or not

    public MyCharacterController controller;
    public Animator animator;

	// Use this for initialization
	void Start () {
        health = 5;
        speed = 10;
	}

    private void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        jump = Input.GetKeyDown(KeyCode.Space);

        animator.SetFloat("Speed", movement.magnitude);

        movement *= speed;
    }

    private void FixedUpdate() {
        StartCoroutine(controller.Move(movement, jump));
    }

    public void OnJump(bool isJumping) {
        animator.SetBool("Jumping", isJumping);
    }
}
