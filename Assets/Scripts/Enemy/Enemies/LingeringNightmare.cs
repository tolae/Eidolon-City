using UnityEngine;

public class LingeringNightmare : BasicEnemy {

    new public void IsPlayerFound(bool isFound, GameObject unused) {
        base.IsPlayerFound(isFound, null);

        world.BroadcastMessage("HivemindTendency", new Hivemind.HivemindParameter(gameObject.tag, isFound));
    }

    new void Start() {
        base.Start();
    }

    new void FixedUpdate() {
        base.FixedUpdate();
    }

    public override void HivemindTrigger(bool isFound,
        Hivemind.HivemindParameter param) {
        base.IsPlayerFound(isFound, null);
    }

    public override void SpawnerTrigger(Spawner.SpawnerParameter param) {
        throw new System.NotImplementedException();
    }

    public override void MobMentalityTrigger(bool isFound, MobMentality.MobMentalityParameter param) {
        throw new System.NotImplementedException();
    }

    public override void HorrorTrigger(bool isFound, Horror.HorrorParameter param) {
        throw new System.NotImplementedException();
    }
}
