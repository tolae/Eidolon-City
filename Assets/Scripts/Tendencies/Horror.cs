using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horror : Tendency {

    float slowdown = 0.75f;
    bool playerFound;

    const Tendency_Type type = Tendency_Type.HORROR;

	public class HorrorParameter : ITendencyParameter {
        public float slowdown;

        public HorrorParameter(float sd) {
            slowdown = sd;
        }
    }

    public void IsPlayerFound(bool isFound, GameObject player) {
        playerFound = isFound;
        tendencyEvent.Invoke(type, isFound, new HorrorParameter(slowdown));
    }

    public override bool IsActive() {
        return playerFound;
    }
}
