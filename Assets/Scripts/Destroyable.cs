using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Interface that all objects that take damage should implement.*
 * For the bullet class.                                        */
public interface Destroyable {

    /* Applies damage to the destroyable object. */
    void TakeDamage(float damage);
}
