using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour, Destroyable {
    /* Params Specific to this enemy */
    [SerializeField] private float health;
    [SerializeField] private float speed;
    private bool playerFound = false;

    public World world;

    public EnemyController controller; /* Controls the enemies basic movement */
    public Animator animator; /* Selects which animation to be playing at what time */
    public new SpriteRenderer renderer; /* Used to change the color when hit */

    public GameObject capturable;

    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            Instantiate(capturable, transform.position, Quaternion.identity);
            Destroy(gameObject);
        } else {
            //TODO change to animation
            Color redtint = new Color(255f, 0f, 0f, 0.5f);
            renderer.material.SetColor("TintColor", redtint);
        }
    }

    public void foundPlayer() {
        playerFound = true;
    }

    public void lostPlayer() {
        playerFound = false;
    }

    private void Start() {
        capturable.GetComponent<Capturable>().world = world;
    }

    private void FixedUpdate() {
        StartCoroutine(controller.Move(world.player.transform.position, speed, playerFound));
    }
}
