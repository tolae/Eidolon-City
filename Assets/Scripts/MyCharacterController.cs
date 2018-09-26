using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MyCharacterController : MonoBehaviour {
    /*General Fields*/
    private float jumpTime = 3f; //Seconds
    private float jumpCooldown = 1f; //Seconds
    private bool isJumping = false;
    private Rigidbody2D rigidbody2D;

    private Vector2 reference_velocity = Vector2.zero;
    [Range(0, 0.3f)] [SerializeField] private float movement_smoothing = 0.05f;
    /*Events*/
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    public BoolEvent onJumpEvent; //For when the player jumps up from the land

    private void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();

        if (onJumpEvent == null)
            onJumpEvent = new BoolEvent();
    }

    public IEnumerator Move(Vector2 move, bool jump) {
        /* If not jumping, move using the move command.       *
         * If jumping, move at the constant velocity when the *
         * player decided to jump.                            */
        if (!isJumping) {
            rigidbody2D.velocity = Vector2.SmoothDamp(
                rigidbody2D.velocity,
                move,
                ref reference_velocity,
                movement_smoothing);
        }
        /*Make sure the Player cannot constantly jump*/
        if (jump && !isJumping) {
            isJumping = true;
            onJumpEvent.Invoke(isJumping);
            yield return new WaitForSeconds(jumpTime);
            isJumping = false;
            onJumpEvent.Invoke(isJumping);
            yield return new WaitForSeconds(jumpCooldown);
        }
    }
}
