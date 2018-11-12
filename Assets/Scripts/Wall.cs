using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Its a wall. Should be indestructable but still technically takes damage. */
public class Wall : MonoBehaviour, Destroyable {

    IEnumerator Destroyable.TakeDamage(Vector2 directional, float damage) {
        //TODO make destroyable walls?
        yield return null;
    }
}
