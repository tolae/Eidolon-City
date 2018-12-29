using UnityEngine;
using UnityEngine.Events;

public class RangeSensor : MonoBehaviour {

    [System.Serializable]
    public class SensorEvent : UnityEvent<bool, GameObject> { }
    public SensorEvent onTagDetection;
    public new string tag;
    public bool isTrigger;

    private void Start() {
        if (onTagDetection == null) {
            onTagDetection = new SensorEvent();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag(tag)) {
            onTagDetection.Invoke(true, collider.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if (!isTrigger && collider.CompareTag(tag)) {
            onTagDetection.Invoke(true, collider.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.CompareTag(tag)) {
            onTagDetection.Invoke(false, collider.gameObject);
        }
    }
}
