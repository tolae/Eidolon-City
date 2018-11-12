using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Container for the world of the player */
public class World : MonoBehaviour {

    public GameController game; /* Current game session */
    public Player player; /* Current player */
    public BasicEnemy enemy; /* The enemy to be created */
    public List<BasicEnemy> basicEnemies; /* Basic enemies in the world */
    public Transform spawnLocation; /* Spawn location for the player */

    private List<BasicEnemy> enemyList;

    private void Awake() {
        enemyList = new List<BasicEnemy>();
    }

    private void Start() {
        /* Creates the player as a child of this object */
        player = Instantiate(player, spawnLocation.position, spawnLocation.rotation, transform);

        /* Sets the players crosshairs */
        player.controller.crosshair = game.crosshair;
        player.weapon.crosshair = game.crosshair;

        /* Creates an enemy as a child of this object */
        enemy = Instantiate(enemy, new Vector3(-10, 0, 0), Quaternion.identity, transform);
        enemy.world = game.world;
        enemy = Instantiate(enemy, new Vector3(-10, 20, 0), Quaternion.identity, transform);
        enemy.world = game.world;
        enemy = Instantiate(enemy, new Vector3(-10, 10, 0), Quaternion.identity, transform);
        enemy.world = game.world;
        enemy = Instantiate(enemy, new Vector3(-15, 30, 0), Quaternion.identity, transform);
        enemy.world = game.world;
        enemyList.Add(enemy);

        /* Set the Virutal Camera to follow the player */
        game.vCam.Follow = player.transform;
    }

}
