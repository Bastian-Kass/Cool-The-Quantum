using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
    public static SpawnerBehaviour SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool = 100;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start(){
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for( int i = 0; i < amountToPool; i++){
            tmp = Instantiate(objectToPool, transform) as GameObject;
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i= 0; i< amountToPool; i++)
            if(!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        
        return null;
    }
    
    public void SpawnParticle(Transform spawner_transform){
        GameObject HeatParticle = SpawnerBehaviour.SharedInstance.GetPooledObject();

        if(HeatParticle != null){
            HeatParticle.transform.position = spawner_transform.position;
            HeatParticle.transform.rotation = spawner_transform.rotation;
            HeatParticle.SetActive(true);
        }

    }
    
}
