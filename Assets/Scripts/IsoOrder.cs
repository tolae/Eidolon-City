using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script that should be applied to all objects.        *
 * Reorders the sortingorder on a sorting layer         *
 * based off its x and y position (since we in 2.5D)    */
public class IsoOrder : MonoBehaviour {

    new SpriteRenderer renderer;
	// Use this for initialization
	void Start () {
        renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        IsoOrdering();
	}

    /* Method that handles the layering. */
    private void IsoOrdering() {
        renderer.sortingOrder = Mathf.RoundToInt(transform.localPosition.x + transform.localPosition.y);
    }
}
