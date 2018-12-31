using System.Collections.Generic;
using UnityEngine;

/**
 * Container for the world of the player */
public class World : MonoBehaviour {

    public Player player;
    [HideInInspector] public Player currentPlayer; /* Current player */
    public BasicEnemy enemy; /* The enemy to be created */
    public List<BasicEnemy> basicEnemies; /* Basic enemies in the world */
    public Transform spawnLocation; /* Spawn location for the player */

    private List<BasicEnemy> enemyList;

    private void Awake() {
        enemyList = new List<BasicEnemy>();
    }

    private void Start() {
        /* Creates the player as a child of this object */
        currentPlayer = Instantiate(player, spawnLocation.position, spawnLocation.rotation, transform);

        /* Creates an enemy as a child of this object */
        enemy = Instantiate(enemy, new Vector3(-10, 0, 0), Quaternion.identity, transform);
        enemy = Instantiate(enemy, new Vector3(-20, 0, 0), Quaternion.identity, transform);
        enemyList.Add(enemy);

        /* Set the Virutal Camera to follow the player */
        GameController.instance.vCam.Follow = currentPlayer.transform;
    }

    public void Clean() {
        foreach (BasicEnemy be in enemyList) {
            Destroy(be);
        }

        enemyList.Clear();
    }

    public void CleanObject(GameObject remove) {
        this.BroadcastMessage("RemoveObjectRef", remove);
    }
}
