using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FesteringAnxiety : BasicEnemy {

    private const string NAME = "FesteringAnxiety";

    // Use this for initialization
    new void Start () {
        base.Start();
        name = NAME;
	}

    public override void SpawnerTrigger(Spawner.SpawnerParameter param) {
        param.spawn.GetComponent<BasicEnemy>().world = world;
        Instantiate(param.spawn, transform.position, Quaternion.identity, world.transform);
    }

    public override void HivemindTrigger(bool isFound, Hivemind.HivemindParameter param) {
        throw new System.NotImplementedException();
    }
}
