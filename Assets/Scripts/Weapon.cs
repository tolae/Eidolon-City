using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] private Transform bulletPointForward;
    [SerializeField] private Transform bulletPointBackward;
    [SerializeField] private Transform bulletPointUp;
    [SerializeField] private Transform bulletPointDown;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Crosshair crosshair;

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    public void Shoot() {
        //Change bullet direction and spawn location depending on crosshair position
        if (transform.rotation.z == 0 && crosshair.transform.position.y < transform.position.y) {
            Instantiate(bullet, bulletPointDown.position, bulletPointDown.rotation);
        } else if (transform.rotation.z == 0 && crosshair.transform.position.y > transform.position.y) {
            Instantiate(bullet, bulletPointUp.position, bulletPointUp.rotation);
        } else if (crosshair.transform.position.x < transform.position.x) {
            Instantiate(bullet, bulletPointBackward.position, bulletPointBackward.rotation);
        } else {
            Instantiate(bullet, bulletPointForward.position, bulletPointForward.rotation);
        }
    }
}
