using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capturable : MonoBehaviour {

    [SerializeField] private int points = 0;
    [SerializeField] private float currTime = 0;
    [SerializeField] private float deadTime = 5;

    public World world;
    public GameController gameController;
    public GameObject original;

    private void Start() {
        original.GetComponent<BasicEnemy>().world = world;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            gameController.Captured(points);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() {
        if (currTime >= deadTime) {
            Destroy(gameObject);
            if (original != null) {
                Instantiate(original, transform.position, Quaternion.identity, world.transform);
            }
        }

        currTime += Time.deltaTime;
    }
}
