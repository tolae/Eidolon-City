using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * This class holds and handles the crosshair information.      *
 * It calculates its position based on the mouse. It does not   *
 * handle clicking events.                                      */
public class Crosshair : MonoBehaviour {

    public Animator animator; /* Animation manager */
    public LayerMask layerMask; /* The layer on which the cross hair resides */

    [Range(0, 0.3f)] [SerializeField] private float trackingSpeed = 0.01f; /* The speed factor of the crosshair */
    private Vector2 mousePosition = Vector2.zero; /* Holds the current mouse position */
    private Vector2 reference_velocity = Vector2.zero; /* Use for smoothing, always 0 */

    private Collider2D[] crosshairHover; /* Holds the different colliders underneath the crosshair */
    private Vector2 lowerCorner = new Vector2(); /* Holds the current lower corner of the crosshair */
    private Vector2 upperCorner = new Vector2(); /* Holds the current upper corner of the crosshair */

    private void FixedUpdate() {
        Move();
        CheckHover();
    }

    /* Calculates the mouse position based of the mouse. Moves the crosshair accordingly */
    private void Move() {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = Vector2.SmoothDamp(
                    transform.position,
                    mousePosition,
                    ref reference_velocity,
                    trackingSpeed);
    }

    /* Checks whether the crosshair is hovering over something. *
     * Plays an animiation for each or groups of colliders.     */
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

    /* Shoot trigger method. Changes the animation to shooting. */
    public void OnShoot() {
        animator.SetTrigger("Shooting");
    }
}
