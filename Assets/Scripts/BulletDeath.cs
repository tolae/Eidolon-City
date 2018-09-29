using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeath : MonoBehaviour {

    [SerializeField] private Animator animator;
    private float aliveTime = 0f;

    private void FixedUpdate() {
        aliveTime += Time.deltaTime;
        if (aliveTime > animator.GetCurrentAnimatorStateInfo(0).length)
            Destroy(gameObject);
    }

}
