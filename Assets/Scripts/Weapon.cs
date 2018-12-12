using UnityEngine;
using UnityEngine.Events;

/** 
 * This class handles when the player should fire and which way the bullet should be facing. */
public class Weapon : MonoBehaviour {

    [SerializeField] private Transform bulletPointForward; /* Forward position for the bullet to be fired. */
    public Bullet bullet; /* Bullet prefab that gets fired for this weapon */
    public Crosshair crosshair; /* Crosshair of the world */
    public UnityEvent shootEvent; /* Notifies all that player is shooting */

    private void Awake() {
        if (shootEvent == null)
            shootEvent = new UnityEvent();
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    /* Fires the bullet. */
    private void Shoot() {
        Instantiate(bullet, bulletPointForward.position, bulletPointForward.rotation);

        shootEvent.Invoke();
    }
}
