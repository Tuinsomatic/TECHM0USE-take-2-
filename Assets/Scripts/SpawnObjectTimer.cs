using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectTimer : MonoBehaviour {

    public float spawnTime = 5.0f;

	void Start () {
        Invoke("DoSpawn", spawnTime);
	}

    void DoSpawn()
    {
        SendMessage("Spawn");
        Invoke("DoSpawn", spawnTime);
        if (spawnTime == 1)
        {
            spawnTime = 1;
        }
        else
        {
            spawnTime -= 0.05f;
        }
    }
}
