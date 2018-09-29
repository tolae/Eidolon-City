using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MyCharacterController : MonoBehaviour {
    /*General Fields*/
    private float jumpTime = 3f; //Seconds
    private float jumpCooldown = 1f; //Seconds
    private bool isJumping = false;
    private new Rigidbody2D rigidbody2D;
    private Vector3 toCrosshair = new Vector3();
    private Quaternion targetRotation = new Quaternion();

    private Vector2 ref_velocity = Vector2.zero;
    [Range(0, 0.3f)] [SerializeField] private float movement_smoothing = 0.05f;
    /*Events*/
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    public BoolEvent onJumpEvent; //For when the player jumps up from the land
    public Crosshair crosshair; //The crosshair for the player

    private void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();

        if (onJumpEvent == null)
            onJumpEvent = new BoolEvent();
    }

    private void FixedUpdate() {
        Rotate();
    }

    private void Rotate() {
        targetRotation = Quaternion.LookRotation(crosshair.transform.position - transform.position);
        targetRotation.x = 0;
        targetRotation.y = 0;

        Debug.DrawLine(transform.position, crosshair.transform.position, Color.black, Time.deltaTime);

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
