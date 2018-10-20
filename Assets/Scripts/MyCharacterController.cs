using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/**
 * This class handles all of the Players controls. */
public class MyCharacterController : MonoBehaviour {
    /*General Fields*/
    private float jumpTime = 3f; /* Hold long the player jumps for (in seconds) */
    private float jumpCooldown = 1f; /* How long it takes to be able to jump again (in seconds) */
    private bool isJumping = false; /* If the player is currently jumping or not */
    private new Rigidbody2D rigidbody2D; /* Rigidbody component */
    private Vector3 toCrosshair = new Vector3(); /* The direction of the crosshair relative to the player */
    private Quaternion targetRotation = new Quaternion(); /* Rotation to turn towards the crosshair */

    private Vector2 ref_velocity = Vector2.zero; /* Always zero */
    [Range(0, 0.3f)] [SerializeField] private float movement_smoothing = 0.05f; /* How much the movement should be smoothed */
    /*Events*/
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    public BoolEvent onJumpEvent; /* For when the player jumps up from the land */
    public Crosshair crosshair; /* The crosshair of the current world */

    private void Awake() {
        /* Instantiates components */
        rigidbody2D = GetComponent<Rigidbody2D>();

        if (onJumpEvent == null)
            onJumpEvent = new BoolEvent();
    }

    private void FixedUpdate() {
        Rotate();
    }

    /* Rotates the player to face where the crosshair currently is. */
    /* Might move this to the weapon class as that doesnt have visuals */
    private void Rotate() {
        /* Debugging line */
        Debug.DrawLine(transform.position, crosshair.transform.position, Color.black, Time.deltaTime);
        /* Vector to the crosshair from the players position */
        toCrosshair = crosshair.transform.position - transform.position;
        /* Angle at which this vector creates with the +x-axis */
        float angle = Vector3.Dot(toCrosshair, Vector3.right);
        angle = angle / (toCrosshair.magnitude * Vector3.right.magnitude);

        /* Checks if the crosshair is below the player. Make the rotation negative if it is */
        /* This prevents the player's rotation to suddenly flip as the rotation will be between 180 and -180 */
        if (toCrosshair.y > 0)
            targetRotation = Quaternion.Euler(0, 0, Mathf.Acos(angle) * Mathf.Rad2Deg);
        else
            targetRotation = Quaternion.Euler(0, 0, Mathf.Acos(angle) * Mathf.Rad2Deg * -1);

        /* Apply the rotation */
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 1);
        
    }

    public IEnumerator Move(Vector2 move, bool jump) {
        /* If not jumping, move using the move command.       *
         * If jumping, move at the constant velocity when the *
         * player decided to jump.                            */
        if (!isJumping) {
            rigidbody2D.velocity = Vector2.SmoothDamp(
                rigidbody2D.velocity,
                move,
                ref ref_velocity,
                movement_smoothing);
        }
        /*Make sure the Player cannot constantly jump*/
        if (jump && !isJumping) {
            isJumping = true;
            onJumpEvent.Invoke(isJumping);
            Debug.Log("Jump Started");
            yield return new WaitForSeconds(jumpTime);
            Debug.Log("Jump Finished");
            isJumping = false;
            onJumpEvent.Invoke(isJumping);
            yield return new WaitForSeconds(jumpCooldown);
        }
    }
}
