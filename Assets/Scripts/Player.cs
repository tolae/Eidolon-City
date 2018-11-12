using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class holds all the information for the Player.
 */
public class Player : MonoBehaviour, Destroyable {

    /*Player Fields*/
    [SerializeField] private float health = 5; /* The number of hitpoints a player can take before death */
    [SerializeField] private float speed = 10;  /* How fast the player moves */
    [SerializeField] private float jumpSpeed = 15; /* How fast the player moves while jumping */
    private Vector2 movement; /* The directional of where the player wants to move */
    private bool jump; /* If the character hit to jump or not */

    public MyCharacterController controller; /* Tells the Player what to do when things happen */
    public Animator animator; /* Selects which animation to be playing at what time */
    public new SpriteRenderer renderer; /* Used to change the color when hit */
    public Weapon weapon; /* The weapon for the player. */

    private new Rigidbody2D rigidbody;

    /* Status */
    private bool canMove;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start() {
        movement = new Vector2();
        jump = false;
        canMove = true;
    }

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (!jump)
            jump = Input.GetKeyDown(KeyCode.Space);

        animator.SetFloat("Speed", movement.magnitude);

        movement *= speed;
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
            GameObject.Find("GameController").GetComponent<GameController>().PlayerDead(true);
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
}
