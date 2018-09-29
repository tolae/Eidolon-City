using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 25f;
    public float damage = 5f;
    public float range = 100f;
    public float aliveTime = 5f;
    private float distanceTravelled = 0f;
    private float time = 0f;

    private new Rigidbody2D rigidbody2D;
    private new CircleCollider2D collider;

    private void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
    }

    private void Start() {
        rigidbody2D.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //TODO If destroyable, do dmg.
        Destroy(gameObject);
    }

    private void FixedUpdate() {
        distanceTravelled += (rigidbody2D.velocity.magnitude * Time.deltaTime);
        time += Time.deltaTime;
        if (distanceTravelled > range || time > aliveTime)
            Destroy(gameObject);
    }
}
