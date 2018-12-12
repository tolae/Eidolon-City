using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicEnemy : MonoBehaviour, Destroyable {
    /* Params Specific to this enemy */
    [SerializeField] protected float health;
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    [SerializeField] protected float attackSpeed;
    protected float attackTimeStart = 0;
    protected bool playerFound = false;

    public World world;

    protected new Rigidbody2D rigidbody;
    protected EnemyController controller; /* Controls the enemies basic movement */
    protected Animator animator; /* Selects which animation to be playing at what time */
    protected new SpriteRenderer renderer; /* Used to change the color when hit */
    [SerializeField] GameObject capturable;

    /* Tendencies of this enemy */
    public List<Tendency.Tendency_Type> tendencyList;

    public IEnumerator TakeDamage(Vector2 directional, float damage) {
        health -= damage;
        if (health <= 0) {
            GameObject inst = Instantiate(capturable, transform.position, Quaternion.identity);
            inst.GetComponent<Capturable>().gameController = world.game;
            world.CleanObject(gameObject);
            Destroy(gameObject);
        } else {
            //TODO change to animation
            Color redtint = new Color(255f, 0f, 0f, 0.5f);
            renderer.material.SetColor("TintColor", redtint);
        }

        yield return null;
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

    public virtual void IsPlayerFound(bool isFound, GameObject unused) {
        playerFound = isFound;
    }

    public virtual void OnAttackTrigger(bool unused, GameObject attacked) {
        if (Time.time - (attackTimeStart + attackSpeed) >= 0) {
            Vector2 directional = attacked.transform.position - transform.position;

            StartCoroutine(
                attacked.GetComponent<Destroyable>()
                    .TakeDamage(directional.normalized, damage));

            attackTimeStart = -1;
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
                case Tendency.Tendency_Type.MOB_MENTALITY:
                    MobMentalityTrigger(trigger, (MobMentality.MobMentalityParameter) param);
                    break;
                case Tendency.Tendency_Type.HORROR:
                    HorrorTrigger(trigger, (Horror.HorrorParameter) param);
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

    public abstract void MobMentalityTrigger(bool isFound,
        MobMentality.MobMentalityParameter param);

    public abstract void HorrorTrigger(bool isFound,
        Horror.HorrorParameter param);
}
