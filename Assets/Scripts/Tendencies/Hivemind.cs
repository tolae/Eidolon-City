using UnityEngine;

public class Hivemind : Tendency {

    string hivemindName;
    int hivemindCount;

    public class HivemindParameter {
        public string name;
        public bool found;

        public HivemindParameter(string name, bool found) {
            this.name = name;
            this.found = found;
        }
    }

    void Start() {
        hivemindName = gameObject.name;
        hivemindCount = 0;
    }

    void FixedUpdate() {
        if (hivemindCount > 0) { tendencyEvent.Invoke(type_pair[1]); }
    }

    void HivemindTendency(HivemindParameter parameter) {
        if (string.Compare(hivemindName, parameter.name, true) == 0 && parameter.found) {
            hivemindCount++;
            tendencyEvent.Invoke(type_pair[1]);
        } else if (!parameter.found) {
            hivemindCount--;
            tendencyEvent.Invoke(type_pair[0]);
        }
    }
}
