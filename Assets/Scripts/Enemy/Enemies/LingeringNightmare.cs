using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingeringNightmare : BasicEnemy {

    private const string NAME = "LingeringNightmare";

    new public void IsPlayerFound(bool isFound) {
        base.IsPlayerFound(isFound);

        world.BroadcastMessage("HivemindTendency", new Hivemind.HivemindParameter(gameObject.name, isFound));
    }

    new void Start() {
        base.Start();
        name = NAME;
    }

    new void FixedUpdate() {
        base.FixedUpdate();
    }

    public override void HivemindTrigger(bool isFound,
        Hivemind.HivemindParameter param) {
        base.IsPlayerFound(isFound);
    }

    public override void SpawnerTrigger(Spawner.SpawnerParameter param) {
        throw new System.NotImplementedException();
    }
}
