using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void IsoOrdering() {
        renderer.sortingOrder = Mathf.RoundToInt(transform.localPosition.x + transform.localPosition.y);
    }
}
