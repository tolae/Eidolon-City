using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horror : Tendency {
    /* The % slow */
    float slowdown = 0.75f; //TODO Make this customizable, add time of slow
    /* If the player is found, unused */
    bool playerFound;
    /* The tendency type */
    const Tendency_Type type = Tendency_Type.HORROR;
    /* The horror parameter */
	public class HorrorParameter : ITendencyParameter {
        /* The % slow */
        public float slowdown;

        public HorrorParameter(float sd) {
            slowdown = sd;
        }
    }
    /* Function is called when the sensor is tripped */
    public void IsPlayerFound(bool isFound) {
        playerFound = isFound;
        tendencyEvent.Invoke(type, isFound, new HorrorParameter(slowdown));
    }

    public override bool IsActive() {
        return playerFound;
    }
}
