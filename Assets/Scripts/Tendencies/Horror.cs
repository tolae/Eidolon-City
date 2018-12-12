using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horror : Tendency {

    float slowdown = 0.75f;
    bool playerFound;

    const Tendency_Type type = Tendency_Type.HORROR;

	public class HorrorParameter : ITendencyParameter {
        float slowdown;

        public HorrorParameter(float sd) {
            slowdown = sd;
        }
    }

    void FixedUpdate() {
        if (IsActive()) {
            tendencyEvent.Invoke(type, true, new HorrorParameter(slowdown));
        }
    }

    public void IsPlayerFound(bool isFound, GameObject player) {
        playerFound = isFound;
    }

    public override bool IsActive() {
        return playerFound;
    }
}
