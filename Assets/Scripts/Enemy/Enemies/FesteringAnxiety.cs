using UnityEngine;

public class FesteringAnxiety : BasicEnemy {

    // Use this for initialization
    new void Start () {
        base.Start();
	}

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
}
