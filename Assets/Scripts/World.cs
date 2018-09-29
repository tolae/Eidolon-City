using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    public int width = 20;
    public int height = 20;

    public GameObject wall;
    private Vector2 wallPosition = new Vector2();

	// Use this for initialization
	void Start () {
        GenerateAbsoluteBorder();
	}

    private void GenerateAbsoluteBorder() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (x == 0 || y == 0 || x == width - 1 || y == height - 1) {
                    wallPosition.Set(x + transform.position.x, y + transform.position.y);
                    Instantiate(wall, wallPosition, Quaternion.identity);
                }
            }
        }
    }
}
