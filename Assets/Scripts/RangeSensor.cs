using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeSensor : MonoBehaviour {

    bool detected;

    private BasicEnemy attachedEnemy; /* The enemy this sensor is attached too */

    private void Awake() {
        attachedEnemy = GetComponentInParent<BasicEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            attachedEnemy.foundPlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            attachedEnemy.lostPlayer();
        }
    }
}
