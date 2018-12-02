using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BasicEnemy : MonoBehaviour, Destroyable {
    /* Params Specific to this enemy */
    [SerializeField] float health;
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float attackSpeed;
    float attackTimeStart = 0;
    bool playerFound = false;

    public World world;

    new Rigidbody2D rigidbody;
    EnemyController controller; /* Controls the enemies basic movement */
    Animator animator; /* Selects which animation to be playing at what time */
    new SpriteRenderer renderer; /* Used to change the color when hit */
    [SerializeField] GameObject capturable;

    /* Tendencies of this enemy */
    public List<Tendency.Tendency_Type> tendencyList;

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

        rigidbody = GetComponent<Rigidbody2D>();
        controller = GetComponent<EnemyController>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
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

    public void OnTendencyTrigger(Tendency.Tendency_Type type, 
        bool trigger, Tendency.ITendencyParameter param) {
        if (tendencyList.Contains(type)) {
            switch (type) {
                case Tendency.Tendency_Type.HIVEMIND:
                    HivemindTrigger(trigger, (Hivemind.HivemindParameter) param);
                    break;
                case Tendency.Tendency_Type.SPAWNER:
                    SpawnerTrigger((Spawner.SpawnerParameter) param);
                    break;
                default:
                    Debug.LogError("Invalid tendency type: " + type);
                    break;
            }
        }
    }

    public abstract void HivemindTrigger(bool isFound,
        Hivemind.HivemindParameter param);

    public abstract void SpawnerTrigger(Spawner.SpawnerParameter param);
}
