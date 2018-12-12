using UnityEngine;

public class MobMentality : Tendency {

    [SerializeField] float slowdownFactor = 0;

    bool isMobFound;
    GameObject mobFriend;
    const Tendency_Type type = Tendency_Type.MOB_MENTALITY;

    public class MobMentalityParameter : ITendencyParameter {
        public GameObject friend;
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

    public void IsMobFound(bool mob, GameObject go) {
        isMobFound = mob;
        mobFriend = go;
    }

    public override bool IsActive() {
        return true;
    }
}
