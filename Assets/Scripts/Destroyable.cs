using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Interface that all objects that take damage should implement.*
 * For the bullet class.                                        */
public interface Destroyable {

    /* Applies damage to the destroyable object.
     * Args:    directional: The direction on which the damage was applied.
     *          damage: The amount of damage dealt to the destroyable. 
     */
    IEnumerator TakeDamage(Vector2 directional, float damage);
}
