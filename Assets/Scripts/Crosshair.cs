using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Crosshair : MonoBehaviour {

    public Animator animator;

    [Range(0,0.3f)][SerializeField] private float trackingSpeed = 0.01f;
    private Vector2 mousePosition = Vector2.zero;
    private Vector2 reference_velocity = Vector2.zero;
    private CircleCollider2D crosshairCollider; //Change animation based on what its over
    private ContactFilter2D crosshairContactFilter; //What the collider should be hitting
    private Collider2D[] overlapColliders;
    private bool canShoot = true;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.SmoothDamp(
                    transform.position,
                    mousePosition,
                    ref reference_velocity,
                    trackingSpeed);
    }
}
