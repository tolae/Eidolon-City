﻿using System.Collections;
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

    public override void OnTendencyTrigger(Tendency.Tendency_Type type) {
        if (tendencyList.Contains(type)) {
            switch (type) {
                case Tendency.Tendency_Type.HIVEMIND_ON:
                    base.IsPlayerFound(true);
                    break;
                case Tendency.Tendency_Type.HIVEMIND_OFF:
                    base.IsPlayerFound(false);
                    break;
                default:
                    Debug.LogError("Invalid tendency type: " + type);
                    break;
            }
        }
    }
}