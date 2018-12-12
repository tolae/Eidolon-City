using UnityEngine;

public class Hivemind : Tendency {

    const Tendency_Type type = Tendency_Type.HIVEMIND;
    string hivemindName;
    static int hivemindCount;

    public class HivemindParameter : ITendencyParameter {
        public string name;
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
        if (hivemindCount > 0) { tendencyEvent.Invoke(type, true, null); }
    }

    void HivemindTendency(HivemindParameter parameter) {
        if (string.Compare(hivemindName, parameter.name, true) == 0 && parameter.found) {
            hivemindCount++;
            tendencyEvent.Invoke(type, true, parameter);
        } else if (!parameter.found) {
            hivemindCount--;
            tendencyEvent.Invoke(type, false, parameter);
        }
    }

    override
    public bool IsActive() {
        return hivemindCount > 0;
    }
}
