using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackDetection : MonoBehaviour {

    [System.Serializable]
    public class AttackTrigger : UnityEvent<Collider2D> { }
    public AttackTrigger attackTrigger;

    private void Start() {
        if (attackTrigger == null) {
            attackTrigger = new AttackTrigger();
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        attackTrigger.Invoke(collider);
    }
}
