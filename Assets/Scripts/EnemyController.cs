using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void FixedUpdate() {
        Rotate();
    }

    public IEnumerator Move(Vector2 target, float speed) {
        
    }
}
