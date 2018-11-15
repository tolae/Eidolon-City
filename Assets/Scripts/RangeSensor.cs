using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RangeSensor : MonoBehaviour {

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    public BoolEvent onPlayerDetected;

    private void Start() {
        if (onPlayerDetected == null) {
            onPlayerDetected = new BoolEvent();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            onPlayerDetected.Invoke(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            onPlayerDetected.Invoke(false);
        }
    }
}
