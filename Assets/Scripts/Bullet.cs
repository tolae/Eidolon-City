using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] private float speed = 25f;
    [SerializeField] private float damage = 5f;
    [SerializeField] private float range = 100f;
    [SerializeField] private float aliveTime = 5f;
    private float distanceTravelled = 0f;
    private float time = 0f;

    private new Rigidbody2D rigidbody2D;
    private new CircleCollider2D collider;
    [SerializeField] private GameObject bulletDeath;

    private void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
    }

    private void Start() {
        rigidbody2D.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Dead(true);

        Destroyable destroyable = collision.GetComponent<Destroyable>();
        if (destroyable != null) {
            destroyable.TakeDamage(damage);
        }
    }

    private void FixedUpdate() {
        distanceTravelled += (rigidbody2D.velocity.magnitude * Time.deltaTime);
        time += Time.deltaTime;
        if (distanceTravelled > range || time > aliveTime)
            Dead(false);
    }

    private void Dead(bool hit) {
        //Play explosion animation
        if (hit) {
            Instantiate(bulletDeath, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}
