using UnityEngine;

public class Hivemind : Tendency {
    /* Type this tendency is */
    const Tendency_Type type = Tendency_Type.HIVEMIND;
    /* The name of the hivemind where information is shared */
    string hivemindName;
    /* How many people are currently triggering the hivemind */
    static int hivemindCount;

    /* The hivemind parameter */
    public class HivemindParameter : ITendencyParameter {
        /* The name of the hivemind */
        public string name;
        /* Whether this object found the target */
        public bool found;

        public HivemindParameter(string name, bool found) {
            this.name = name;
            this.found = found;
        }
    }

    void Start() {
        hivemindName = gameObject.tag;
    }

    void FixedUpdate() {
        if (IsActive()) { tendencyEvent.Invoke(type, true, null); }
    }
    /* The hivemind tendency callback function */
    void HivemindTendency(HivemindParameter parameter) {
        /* If both objects are in the same hivemind and the target object is in view */
        if (string.Compare(hivemindName, parameter.name, true) == 0 && parameter.found) {
            hivemindCount++;
            tendencyEvent.Invoke(type, true, parameter);
        } 
        /* If the target object left view of one of the hivemind members */
        else if (!parameter.found) {
            hivemindCount--;
            tendencyEvent.Invoke(type, false, parameter);
        }
    }

    override
    public bool IsActive() {
        return hivemindCount > 0;
    }
}
