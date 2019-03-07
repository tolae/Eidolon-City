using UnityEngine;

public class FesteringAnxiety : BasicEnemy {

    public override void SpawnerTrigger(Spawner.SpawnerParameter param) {
        param.spawn.GetComponent<BasicEnemy>().world = world;
        Instantiate(param.spawn, transform.position, Quaternion.identity, world.transform);
    }

    public override void MobMentalityTrigger(bool isFound, MobMentality.MobMentalityParameter param) {
        if (isFound) {
            StartCoroutine(controller.Move(param.friend.transform.position, speed * param.slowdownFactor, isFound));
        }
    }

    public override void HivemindTrigger(bool isFound, Hivemind.HivemindParameter param) {
        throw new System.NotImplementedException();
    }

    public override void HorrorTrigger(bool isFound, Horror.HorrorParameter param) {
        throw new System.NotImplementedException();
    }
}
