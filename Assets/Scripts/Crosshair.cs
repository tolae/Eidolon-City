using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Crosshair : MonoBehaviour {

    public Animator animator;
    public LayerMask layerMask;

    [Range(0, 0.3f)] [SerializeField] private float trackingSpeed = 0.01f;
    private Vector2 mousePosition = Vector2.zero;
    private Vector2 reference_velocity = Vector2.zero;

    private Collider2D[] crosshairHover;
    private Vector2 lowerCorner = new Vector2();
    private Vector2 upperCorner = new Vector2();

    private void FixedUpdate() {
        Move();
        CheckHover();
    }

    private void Move() {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.SmoothDamp(
                    transform.position,
                    mousePosition,
                    ref reference_velocity,
                    trackingSpeed);
    }

    private void CheckHover() {
        upperCorner.Set(
            transform.position.x + transform.localScale.x / 2f,
            transform.position.y + transform.localScale.y / 2f);
        lowerCorner.Set(
            transform.position.x - transform.localScale.x / 2f,
            transform.position.y - transform.localScale.y / 2f);

        crosshairHover = Physics2D.OverlapAreaAll(lowerCorner, upperCorner, layerMask);

        //TODO Do specific actions for certain colliders
        if (crosshairHover.Length > 0)
            animator.SetBool("Hovering", true);
        else
            animator.SetBool("Hovering", false);
    }

    public void OnShoot() {
        animator.SetTrigger("Shooting");
    }
}
