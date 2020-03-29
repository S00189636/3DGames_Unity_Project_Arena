using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Spawner : MonoBehaviour
{


    public GameObject[] spawnObjects;
    public Transform[] Locations;
    public bool SpawnOnStart;
    public float SpawnEvery;

    SpawnLocation[] spawnLocations;
    float timeToSpawn;


    private void Start()
    {
        spawnLocations = new SpawnLocation[Locations.Length];
        for (int i = 0; i < Locations.Length; i++)
        {
            spawnLocations[i] = new SpawnLocation(Locations[i]);
            if (SpawnOnStart)
                spawnLocations[i].Spawn(spawnObjects[Random.Range(0, spawnObjects.Length)]);
        }

        timeToSpawn = Time.time + SpawnEvery;
    }

    private void Update()
    {
        if (Time.time >= timeToSpawn)
        {
            timeToSpawn = Time.time + SpawnEvery;
            foreach (var item in spawnLocations)
            {

                if (item.HasWeapon)
                {
                    if (item.CurrentSpawnObject == null)
                        item.HasWeapon = false;
                    continue;
                }
                else
                {
                    item.Spawn(spawnObjects[Random.Range(0, spawnObjects.Length)]);
                    break;
                }
            }
        }
    }


    private class SpawnLocation
    {
        Transform Transform;
        public bool HasWeapon;
        public GameObject CurrentSpawnObject;
        public Vector3 location { get { return Transform.position; } }
        public SpawnLocation(Transform transform)
        {
            Transform = transform;
        }

        public void Spawn(GameObject gameObject)
        {
            CurrentSpawnObject = Instantiate(gameObject, location, Transform.rotation);
            HasWeapon = true;
        }

    }
}
