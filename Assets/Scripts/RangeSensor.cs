using UnityEngine;
using UnityEngine.Events;

public class RangeSensor : MonoBehaviour {

    /* System event that gets called whenever the sensor is triggered *
     * Takes two parameters:
     *      bool: The tag object is within the bounds of the sensor
     *      GameObject: The game object that tripped the sensor
     */
    [System.Serializable]
    public class SensorEvent : UnityEvent<bool, GameObject> { }
    public SensorEvent onTagDetection;
    /* Specific tag to look for */
    public new string tag;
    /* Set if this sensor is a continuous effect */
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
