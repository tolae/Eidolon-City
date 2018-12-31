using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Tendency {
    /* The unit this tendency will spawn */
    public GameObject spawning;
    /* The minimum time it takes to spawn the unit */
    public float minSpawningTime;
    /* The maximum time it takes to spawn the unit */
    public float maxSpawningTime;
    /* Time until the next spawn */
    float timeNext = -1;
    /* Time of the previous spawn */
    float timePrevious = 0;
    /* The tendency type */
    const Tendency_Type type = Tendency_Type.SPAWNER;
    /* The tendency parameter */
    public class SpawnerParameter : ITendencyParameter {
        /* The unit that will be spawned */
        public GameObject spawn;

        public SpawnerParameter(GameObject go) {
            spawn = go;
        }
    }

	// Use this for initialization
	void Start () {
		if (spawning == null) {
            Debug.LogError("No spawning unit for tendency!");
        } else {
            /* Set the time to some point between the min and max timers */
            timeNext = Random.Range(minSpawningTime, maxSpawningTime);
        }
	}
	
	// Update is called once per frame
	void Update () {
        /* Currently off */
        if (timeNext == -1)
            return;
        /* Time elasped from the previous time */
        timePrevious += Time.deltaTime;

        if (timePrevious >= timeNext) {
            /* Call the function callback */
            tendencyEvent.Invoke(type, true, new SpawnerParameter(spawning));
            /* Reset the time variables */
            timeNext = Random.Range(minSpawningTime, maxSpawningTime);
            timePrevious = 0;
        }
	}

    override
    public bool IsActive() {
        return true;
    }
}
