using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Tendency {

    public GameObject spawning;
    public float minSpawningTime;
    public float maxSpawningTime;
    public int maxSpawn;
    int currSpawn = 0;
    float timeNext = -1;
    float timePrevious = 0;
    const Tendency_Type type = Tendency_Type.SPAWNER;

    public class SpawnerParameter : ITendencyParameter {
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
            timeNext = Random.Range(minSpawningTime, maxSpawningTime);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (timeNext == -1)
            return;

        timePrevious += Time.deltaTime;

        if (timePrevious >= timeNext)
            spawnUnit();
	}

    override
    public bool IsActive() {
        return true;
    }

    void spawnUnit() {
        if (currSpawn < maxSpawn) {
            tendencyEvent.Invoke(type, true, new SpawnerParameter(spawning));
            currSpawn++;
        }
        timeNext = Random.Range(minSpawningTime, maxSpawningTime);
        timePrevious = 0;
    }
}
