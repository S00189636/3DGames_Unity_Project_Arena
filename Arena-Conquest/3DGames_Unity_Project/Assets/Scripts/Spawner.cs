using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool IsRandom;
    public float MaxObjects;
    public GameObject[] spawnObjects;
    public Transform[] Locations;
    List<GameObject> CurrentObjects = new List<GameObject>();
    int currentLocationIndex = 0;
    int currentObjectIndex = 0;

    public float SpawnEvery;

    GameObject Spawn(int index, int locationIndex)
    {
        return Instantiate(spawnObjects[index], Locations[locationIndex].position, Locations[locationIndex].rotation);
    }

    private void Update()
    {

        if (CurrentObjects.Count < MaxObjects)
        {
            Debug.Log($"{CurrentObjects.Count}");
            switch (IsRandom)
            {
                case false:
                    CurrentObjects.Add(Spawn(currentObjectIndex, currentLocationIndex));
                    currentLocationIndex++;
                    currentLocationIndex = Mathf.Clamp(currentLocationIndex, 0, Locations.Length);
                    currentObjectIndex++;
                    currentObjectIndex = Mathf.Clamp(currentObjectIndex, 0, spawnObjects.Length);
                    break;
                case true:
                    currentLocationIndex = Random.Range(0, Locations.Length);
                    currentObjectIndex = Random.Range(0, spawnObjects.Length);
                    CurrentObjects.Add(Spawn(currentObjectIndex, currentLocationIndex));
                    break;
            }

        }
        else
        {
            int remove = -1;
            for (int i = 0; i < CurrentObjects.Count; i++)
            {
                if (CurrentObjects[i].gameObject == null)
                {
                    remove = i;
                    Debug.Log($"we will remove  {i}");
                    break;
                }
            }
            if (remove >= 0)
                CurrentObjects.RemoveAt(remove);
        }
    }
}
