using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachingParticleSpawner : MonoBehaviour
{
    public SpawnerBehaviour spawnerArena;
    public GameObject HeatParticle;
    public bool spawning = true;

    // Start is called before the first frame update
    void Start()
    {
        // float randomTime = Random.Range(your min, your max )

        StartCoroutine(Spawn_ApproachingParticle());
    }

    IEnumerator Spawn_ApproachingParticle()
    {
        float randomTime = Random.Range(5, 10);

        while(spawning){
            yield return new WaitForSeconds(randomTime);
            // Debug.Log(randomTime);

            spawnerArena.SpawnParticle( transform );
            randomTime = Random.Range(5, 10);
        }

    }
}
