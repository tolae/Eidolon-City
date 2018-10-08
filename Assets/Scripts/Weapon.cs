using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour {

    [SerializeField] private Transform bulletPointForward;
    public Bullet bullet;
    public Crosshair crosshair;
    public UnityEvent shootEvent;

    private readonly float z_bug = 0.5f;

    private void Awake() {
        if (shootEvent == null)
            shootEvent = new UnityEvent();
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    public void Shoot() {
        Instantiate(bullet, bulletPointForward.position, bulletPointForward.rotation);

        shootEvent.Invoke();
    }
}
