using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class applies the death animation.              *
 * It destroys itself when the animation is complete    */
public class BulletDeath : MonoBehaviour {

    [SerializeField] private Animator animator; /* Animation manager component */
    private float aliveTime = 0f; /* How long the object has been alive */

    private void FixedUpdate() {
        aliveTime += Time.deltaTime; /* Accumulate */
        if (aliveTime > animator.GetCurrentAnimatorStateInfo(0).length) /* Check and destroy */
            Destroy(gameObject);
    }

}
