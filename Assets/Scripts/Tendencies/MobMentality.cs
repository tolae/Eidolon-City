using UnityEngine;

public class MobMentality : Tendency {
    /* How fast these units move to each other (a %) */
    [SerializeField] float slowdownFactor = 0;
    /* The other unit is found */
    bool isMobFound;
    /* The mob unit object */
    GameObject mobFriend;
    /* The tendency type */
    const Tendency_Type type = Tendency_Type.MOB_MENTALITY;
    /* The Mob Parameter */
    public class MobMentalityParameter : ITendencyParameter {
        /* The friend unit */
        public GameObject friend;
        /* How fast the unit will move to each other */
        public float slowdownFactor;

        public MobMentalityParameter(GameObject go, float slowdown) {
            friend = go;
            slowdownFactor = slowdown;
        }
    }

    // Use this for initialization
    void Start () {
        isMobFound = false;
        mobFriend = null;
	}

    // Update is called once per frame
    private void FixedUpdate() {
        tendencyEvent.Invoke(type, isMobFound, new MobMentalityParameter(mobFriend, slowdownFactor));
    }
    /* Callback function from the sensor */
    public void IsMobFound(bool mob, GameObject go) {
        isMobFound = mob;
        mobFriend = go;
    }

    public override bool IsActive() {
        return true;
    }

    private void RemoveObjectRef(GameObject remove) {
        if (mobFriend != null) {
            if (mobFriend.Equals(remove)) {
                mobFriend = null;
                isMobFound = false;
            }
        }
    }
}
