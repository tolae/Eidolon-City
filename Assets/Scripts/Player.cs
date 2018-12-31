using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class holds all the information for the Player.
 */
public class Player : MonoBehaviour, Destroyable {

    /* Player Fields */
    public float health = 5; /* The number of hitpoints a player can take before death */
    public float speed = 10;  /* How fast the player moves */
    [HideInInspector] public float currentSpeed;
    //[SerializeField] private float jumpSpeed = 15; /* How fast the player moves while jumping */
    private Vector2 movement; /* The directional of where the player wants to move */
    private bool jump; /* If the character hit to jump or not */

    [SerializeField] private MyCharacterController controller; /* Tells the Player what to do when things happen */
    [SerializeField] private Animator animator; /* Selects which animation to be playing at what time */
    [SerializeField] private new SpriteRenderer renderer; /* Used to change the color when hit */
    [SerializeField] private Weapon weapon; /* The weapon for the player. */
    [SerializeField] private new Rigidbody2D rigidbody;

    /* Status */
    private Dictionary<StatusHandler.Status, bool> statusDict;
    private bool canMove;

    private void Start() {
        statusDict = new Dictionary<StatusHandler.Status, bool>();
        foreach (StatusHandler.Status status in System.Enum.GetValues(typeof(StatusHandler.Status))) {
            statusDict.Add(status, false);
        }
        movement = new Vector2();
        jump = false;
        canMove = true;
        currentSpeed = speed;
    }

    private void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (!jump)
            jump = Input.GetKeyDown(KeyCode.Space);

        animator.SetFloat("Speed", movement.magnitude);

        movement *= currentSpeed;
    }

    private void FixedUpdate() {
        if (canMove) {
            StartCoroutine(controller.Move(movement, jump));
        }
    }
    
    /* TakeDamage method from the destroyable.
     * Damage applied makes the player turn red.    
     */
    public IEnumerator TakeDamage(Vector2 directional, float damage) {
        health -= damage; /* Damage algorithm */
        canMove = false;

        rigidbody.AddForce(5000 * directional);

        if (health <= 0) {
            GameController.instance.PlayerDead(true);
            Destroy(gameObject);
        } else {
            //TODO change animation
            Color redtint = new Color(255f, 0f, 0f, 0.5f);
            renderer.material.SetColor("TintColor", redtint);
        }

        yield return new WaitForFixedUpdate();
        canMove = true;
    }

    /* If the player is jumping, apply jumping animation and reset. */
    public void OnJump(bool isJumping) {
        if (isJumping)
            animator.SetTrigger("Jumping");
        else
            jump = false;
    }

    public void ApplyStatus(StatusHandler.Status status, StatusHandler.IStatusParameter param) {
        if (!statusDict[status]) {
            StatusHandler.instance.HandlePlayerStatus(true, status, param);
            statusDict[status] = true;
        }
    }

    public void RemoveStatus(StatusHandler.Status status) {
        StatusHandler.instance.HandlePlayerStatus(false, status, null);
        statusDict[status] = false;
    }
}
