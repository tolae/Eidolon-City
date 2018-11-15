using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingeringNightmare : BasicEnemy {

    public int hivemindDetect = 0;

    new public void IsPlayerFound(bool isFound) {
        base.IsPlayerFound(isFound);

        world.BroadcastMessage("HivemindTendency", isFound);
    }

    private void HivemindTendency(bool trigger) {
        if (trigger) {
            hivemindDetect++;
        } else {
            hivemindDetect--;
        }
    }

    new void FixedUpdate() {
        base.IsPlayerFound(hivemindDetect > 0);
        base.FixedUpdate();
    }
}
