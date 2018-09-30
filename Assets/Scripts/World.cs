using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    public GameController game;
    public Player player;
    public Transform spawnLocation;

    private void Start() {
        player = Instantiate(player, spawnLocation.position, spawnLocation.rotation, transform);

        player.controller.crosshair = game.crosshair;
        player.weapon.crosshair = game.crosshair;
    }

}
