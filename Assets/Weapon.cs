using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform bulletPointForward;
    public Transform bulletPointBackward;
    public GameObject bullet;
    public Crosshair crosshair;

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    public void Shoot() {
        //Change bullet direction and spawn location
        if (crosshair.transform.position.x < transform.position.x) {
            Instantiate(bullet, bulletPointBackward.position, bulletPointBackward.rotation);
        } else {
            Instantiate(bullet, bulletPointForward.position, bulletPointForward.rotation);
        }
    }
}
