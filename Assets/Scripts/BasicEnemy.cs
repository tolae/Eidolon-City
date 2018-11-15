using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicEnemy : MonoBehaviour, Destroyable {
    /* Params Specific to this enemy */
    [SerializeField] float health;
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float attackSpeed;
    float attackTimeStart = 0;
    bool playerFound = false;

    public World world;

    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] EnemyController controller; /* Controls the enemies basic movement */
    [SerializeField] Animator animator; /* Selects which animation to be playing at what time */
    [SerializeField] new SpriteRenderer renderer; /* Used to change the color when hit */
    [SerializeField] GameObject capturable;

    public IEnumerator TakeDamage(Vector2 directional, float damage) {
        health -= damage;
        if (health <= 0) {
            GameObject inst = Instantiate(capturable, transform.position, Quaternion.identity);
            inst.GetComponent<Capturable>().gameController = world.game;
            Destroy(gameObject);
        } else {
            //TODO change to animation
            Color redtint = new Color(255f, 0f, 0f, 0.5f);
            renderer.material.SetColor("TintColor", redtint);
        }

        yield return null;
    }

    public virtual void IsPlayerFound(bool isFound) {
        playerFound = isFound;
    }

    protected virtual void Start() {
        capturable.GetComponent<Capturable>().world = world;
    }

    protected virtual void FixedUpdate() {
        StartCoroutine(controller.Move(world.player.transform.position, speed, playerFound));
        if (attackTimeStart == -1) {
            attackTimeStart = Time.time;
        }
    }

    public virtual void OnAttack(Collider2D collider) {
        if (collider.CompareTag("Player")) {
            if (Time.time - (attackTimeStart + attackSpeed) >= 0) {
                Vector2 directional = collider.transform.position - transform.position;

                StartCoroutine(
                    collider.GetComponent<Destroyable>()
                        .TakeDamage(directional.normalized, damage));

                attackTimeStart = -1;
            }
        }
    }
}
