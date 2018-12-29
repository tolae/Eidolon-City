using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowStatus : MonoBehaviour {

    public class SlowParameter : StatusHandler.IStatusParameter {
        public float amount;

        public SlowParameter(float amt) {
            amount = amt;
        }
    }

    public static void ApplySlow(Player player, SlowParameter param) {
        player.currentSpeed = player.speed * param.amount;
    }

    public static void RemoveSlow(Player player) {
        player.currentSpeed = player.speed;
    }

}
