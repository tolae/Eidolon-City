using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance = null;
    public World world;
    public Crosshair crosshair;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    private void Start() {
        if (world == null) {
            world = Instantiate(world, transform.position, transform.rotation);
        }

        world.game = instance;

        crosshair = Instantiate(crosshair, world.transform);
    }
}
