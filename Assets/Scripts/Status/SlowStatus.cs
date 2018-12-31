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

    public static void ApplySlow(SlowParameter param) {
        GameController.instance.world.currentPlayer.currentSpeed = 
            GameController.instance.world.currentPlayer.speed * param.amount;
    }

    public static void RemoveSlow() {
        GameController.instance.world.currentPlayer.currentSpeed = 
            GameController.instance.world.currentPlayer.speed;
    }

}
