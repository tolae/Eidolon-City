using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Its a wall. Should be indestructable but still technically takes damage. */
public class Wall : MonoBehaviour, Destroyable {

    void Destroyable.TakeDamage(float damage) {
        //TODO make destroyable walls?
    }
}
