using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [Range(0, 0.3f)] [SerializeField] private float movement_smoothing = 0.05f; /* How much the movement should be smoothed */
    [SerializeField] private Transform directional;

    private bool wasFound = false;

    private Vector3 toPlayer = Vector3.zero; /* The direction of the player relative to the enemy */
    private Vector3 playerPos = Vector3.zero;
    private Quaternion targetRotation = new Quaternion(); /* Rotation to turn towards the player */

    new Rigidbody2D rigidbody2D; /* Rigidbody component */

    private Vector2 ref_velocity = Vector2.zero;

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Rotate() {
        /* Debugging line */
        Debug.DrawLine(directional.position, playerPos, Color.black, Time.deltaTime);
        /* Vector to the crosshair from the players position */
        toPlayer = playerPos - directional.position;
        /* Angle at which this vector creates with the +x-axis */
        float angle = Vector3.Dot(toPlayer, Vector3.right);
        angle = angle / (toPlayer.magnitude * Vector3.right.magnitude);

        /* Checks if the crosshair is below the player. Make the rotation negative if it is */
        /* This prevents the player's rotation to suddenly flip as the rotation will be between 180 and -180 */
        if (toPlayer.y > 0)
            targetRotation = Quaternion.Euler(0, 0, Mathf.Acos(angle) * Mathf.Rad2Deg);
        else
            targetRotation = Quaternion.Euler(0, 0, Mathf.Acos(angle) * Mathf.Rad2Deg * -1);

        /* Apply the rotation */
        directional.rotation = targetRotation;
    }

    public IEnumerator Move(Vector3 target, float speed, bool playerLocated) {
        if (playerLocated) {
            wasFound = true;
            playerPos = target;

            Rotate();

            rigidbody2D.velocity = Vector2.SmoothDamp(
                    rigidbody2D.velocity,
                    directional.right * speed,
                    ref ref_velocity,
                    movement_smoothing);
        }
        if (wasFound && !playerLocated) {
            yield return new WaitForSeconds(1f);
            rigidbody2D.velocity = Vector2.zero;
            wasFound = false;
        }
    }
}
