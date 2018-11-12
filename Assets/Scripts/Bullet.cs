using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *  Bullet class handles aspect of the fired bullet.*
 *  It holds it speed, damage, range, etc.          *
 *  These are customizable from the prefab.         *
 */
public class Bullet : MonoBehaviour {

    [SerializeField] private float speed = 25f; /* Speed at which the bullet travels */
    [SerializeField] private float damage = 5f; /* Damage upon impact */
    [SerializeField] private float range = 100f; /* How far the bullet can travel before destruction */
    [SerializeField] private float aliveTime = 5f; /* How long the bullet lasts */
    private float distanceTravelled = 0f; /* Holds how far this bullet has been traveling */
    private float time = 0f; /* Holds how long the bullet has been alive */

    private new Rigidbody2D rigidbody2D; /* The rigidbody of the bullet */
    [SerializeField] private BulletDeath bulletDeath; /* The bullet's death animation */

    private void Awake() {
        /* Grab components required for the bullet */
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        /* Bullet should start moving upon being spawned *
         * Bullet is automatically oriented to face the correct direction */
        rigidbody2D.velocity = transform.right * speed;
    }

    /* This trigger event occurs when the bullets collider hits something   *
     * The event searches the collision for a Destroyable object            *
     * and applies damage to it. It lets the object being hit handle        * 
     * its own damage                                                       */
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Killable")) {
            Dead(true); /* Kill the bullet, no multi-hits */

            /* Locate destroyable, and apply damage if its found */
            Destroyable destroyable = collision.GetComponent<Destroyable>();
            if (destroyable != null) {
                StartCoroutine(
                    destroyable
                        .TakeDamage(rigidbody2D.velocity.normalized, damage));
            }
        }
    }

    private void FixedUpdate() {
        /* Count its distance and how long its been alive for removal */
        distanceTravelled += (rigidbody2D.velocity.magnitude * Time.deltaTime);
        time += Time.deltaTime;
        if (distanceTravelled > range || time > aliveTime)
            Dead(false);
    }

    /**
     * This function removes this object from the game and  *
     * applies its death animation if it hit something.     *
     * param hit: If this bullet collided with something    */
    private void Dead(bool hit) {
        /* Play explosion animation */
        if (hit) {
            Instantiate(bulletDeath, transform.position, transform.rotation);
        }

        Destroy(gameObject); /* Clean up */
    }
}
