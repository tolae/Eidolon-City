using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Container for the world of the player */
public class World : MonoBehaviour {

    public GameController game; /* Current game session */
    public Player player; /* Current player */
    public Transform spawnLocation; /* Spawn location for the player */

    private void Start() {
        /* Creates the player as a child of this object */
        player = Instantiate(player, spawnLocation.position, spawnLocation.rotation, transform);

        /* Sets the players crosshairs */
        player.controller.crosshair = game.crosshair;
        player.weapon.crosshair = game.crosshair;
    }

}
