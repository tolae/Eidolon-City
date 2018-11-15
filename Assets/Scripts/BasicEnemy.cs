using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicEnemy : MonoBehaviour, Destroyable {
    /* Params Specific to this enemy */
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    public bool playerFound = false;

    public World world;

    public EnemyController controller; /* Controls the enemies basic movement */
    public Animator animator; /* Selects which animation to be playing at what time */
    public new SpriteRenderer renderer; /* Used to change the color when hit */
    
    public GameObject capturable;

    IEnumerator Destroyable.TakeDamage(Vector2 directional, float damage) {
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
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            Vector2 directional = collision.transform.position - transform.position;

            StartCoroutine(
                collision.collider.GetComponent<Destroyable>()
                    .TakeDamage(directional.normalized, damage));
        }
    }
}
