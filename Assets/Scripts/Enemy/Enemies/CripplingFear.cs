﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CripplingFear : BasicEnemy {

    public override void HorrorTrigger(bool isFound, Horror.HorrorParameter param) {
        /* Play scary sounds of aggression */
        //world.player.applyStatus(SLOW, param.slowdown);
    }

    public override void HivemindTrigger(bool isFound, Hivemind.HivemindParameter param) {
        throw new System.NotImplementedException();
    }

    public override void MobMentalityTrigger(bool isFound, MobMentality.MobMentalityParameter param) {
        throw new System.NotImplementedException();
    }

    public override void SpawnerTrigger(Spawner.SpawnerParameter param) {
        throw new System.NotImplementedException();
    }
}